using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjFinalProjectApi.Helpers;
using prjFinalProjectApi.Models;
using prjFinalProjectApi.Models.Dto;
using prjFinalProjectApi.Models.Dtos;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;


namespace prjFinalProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DbNursingHomeContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        public AccountController(DbNursingHomeContext context, IWebHostEnvironment env, IConfiguration config)
        {
            _context = context;
            _env = env;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto dto)
        {
            if (await _context.Members.AnyAsync(m => m.FAccount == dto.Account))
                return BadRequest("帳號已存在");

            if (dto.Password != dto.ConfirmPassword)
                return BadRequest("密碼不一致");

            byte[] salt = GenerateSalt();
            string hashedPassword = HashPassword(dto.Password, salt);

            string? fileName = null;
            if (dto.Photo != null)
            {
                string uploadPath = Path.Combine(_env.WebRootPath!, "images", "members");
                if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

                fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Photo.FileName)}";
                string filePath = Path.Combine(uploadPath, fileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);
                await dto.Photo.CopyToAsync(fileStream);
            }

            var member = new Member
            {
                FAccount = dto.Account,
                FPasswordHash = hashedPassword,
                FPasswordSalt = Convert.ToBase64String(salt),
                FEmail = dto.Email,
                FName = dto.Name,
                FGender = dto.Gender,
                FPhone = dto.Phone,
                FBirthDate = dto.BirthDate != null ? DateOnly.FromDateTime(dto.BirthDate.Value) : null,
                FProfilePictureUrl = fileName,
                FAccountStatus = true,
                FCreatedAt = DateTime.Now
            };

            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return Ok(new { message = "註冊成功" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var member = _context.Members.FirstOrDefault(m => m.FAccount == dto.Account);

            if (member == null)
            {
                //  帳號不存在紀錄
                LogSecurityEvent(null, "LoginFailed", $"帳號不存在：{dto.Account}");
                return Unauthorized(new { message = "帳號不存在" });
            }

            if (!VerifyPassword(dto.Password, member.FPasswordHash, member.FPasswordSalt))
            {
                //  密碼錯誤紀錄
                LogSecurityEvent(member.FMemberId, "LoginFailed", "密碼錯誤");
                return Unauthorized(new { message = "密碼錯誤" });
            }

            //  登入成功產生 Token
            var token = JwtHelper.GenerateToken(
                member.FMemberId,
                member.FAccount,
                member.FEmail,
                _config["Jwt:Key"],
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                60
            );


            //  登入成功紀錄
            LogSecurityEvent(member.FMemberId, "LoginSuccess", "登入成功");

            await SendEmailAsync(
            member.FEmail!,
            "登入成功通知",
            $"<h3>親愛的 {member.FName}，您好！</h3><p>您已於 {DateTime.Now:yyyy/MM/dd HH:mm:ss} 成功登入系統。</p>"
            );

            return Ok(new
            {
                message = "登入成功",
                token,
                memberId = member.FMemberId
            });
        }



        // 產生隨機鹽
        private static byte[] GenerateSalt(int size = 16)
        {
            return RandomNumberGenerator.GetBytes(size);
        }

        // 雜湊密碼
        private static string HashPassword(string password, byte[] salt)
        {
            byte[] hashed = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32);
            return Convert.ToBase64String(hashed);
        }

        // 驗證密碼
        private static bool VerifyPassword(string inputPassword, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            string hashOfInput = HashPassword(inputPassword, saltBytes);
            return hashOfInput == storedHash;
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            var account = User.FindFirstValue(ClaimTypes.Name);
            if (string.IsNullOrEmpty(account))
                return Unauthorized(new { message = "找不到登入資訊" });

            var member = _context.Members.FirstOrDefault(m => m.FAccount == account);
            if (member != null)
            {
                //  登出紀錄
                LogSecurityEvent(member.FMemberId, "Logout", "使用者登出");
            }

            return Ok(new { message = "登出成功" });
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] JsonElement json)
        {
            try
            {
                var idToken = json.GetRawText().Trim('"');

                var payload = await Google.Apis.Auth.GoogleJsonWebSignature.ValidateAsync(idToken);
                var email = payload.Email;
                var name = payload.Name;
                var externalId = payload.Subject;

                // 找出同 email 的帳號，不管是用哪種方式註冊
                var member = await _context.Members.FirstOrDefaultAsync(m => m.FEmail == email);

                if (member == null)
                {
                    //  完全新帳號，建立 Google 帳號
                    member = new Member
                    {
                        FEmail = email,
                        FName = name,
                        FLoginProvider = "Google",
                        FAccount = "google_" + Guid.NewGuid().ToString("N").Substring(0, 10),
                        FAccountStatus = true,
                        FCreatedAt = DateTime.Now,
                        FExternalId = externalId
                    };

                    _context.Members.Add(member);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //  已經有帳號存在
                    //  更新登入方式為 Google（讓他下次可用 Google 直接登入）
                    if (string.IsNullOrEmpty(member.FLoginProvider))
                    {
                        member.FLoginProvider = "Google";
                        member.FExternalId = externalId;
                        await _context.SaveChangesAsync();
                    }
                }

                // 登入成功，產生 JWT Token
                var token = JwtHelper.GenerateToken(
                    member.FMemberId,
                    member.FAccount,
                    member.FEmail,
                    _config["Jwt:Key"],
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    60
                );

                //  登入成功紀錄
                await LogSecurityEvent(member.FMemberId, "LoginSuccess", "Google 登入成功（帳號整合）");

                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                if (ip == "::1") ip = "127.0.0.1";

                await SendEmailAsync(
                    member.FEmail!,
                    "Google 登入通知",
                    $"""
                    <h3>親愛的 {member.FName}，您好：</h3>
                    <p>您已於 <strong>{DateTime.Now:yyyy/MM/dd HH:mm:ss}</strong> 成功使用 <span style='color:green;'>Google 第三方登入</span>。</p>
                      <p><strong>登入 IP 位址：</strong> {ip}</p>
                      <p>若非您本人操作，請立即聯絡系統管理員。</p>
                      <hr/>
                      <small>本信件為系統自動通知，請勿回覆</small>
                    """
                 );

                return Ok(new
                {
                    token,
                    message = "Google 登入成功",
                    memberId = member.FMemberId
                });
            }
            catch (Exception ex)
            {
                await LogSecurityEvent(null, "LoginFailed", $"Google 登入失敗：{ex.Message}");

                return BadRequest(new
                {
                    message = "Google 登入失敗",
                    error = ex.Message
                });
            }
        }





        private async Task LogSecurityEvent(int? memberId, string eventType, string? notes)
        {
            try
            {
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                if (ip == "::1") ip = "127.0.0.1";

                eventType = string.IsNullOrEmpty(eventType) ? null :
                            eventType.Length > 50 ? eventType.Substring(0, 50) : eventType;

                notes = string.IsNullOrEmpty(notes) ? null :
                        notes.Length > 200 ? notes.Substring(0, 200) : notes;

                ip = string.IsNullOrEmpty(ip) ? null :
                     ip.Length > 200 ? ip.Substring(0, 200) : ip;

                // 每次 Log 時自己 new 一個新的 context
                using var db = new DbNursingHomeContext();
                var log = new MemberSecurityLog
                {
                    FMemberId = memberId,
                    FEventType = eventType,
                    FNotes = notes,
                    FIpAddress = ip,
                    FCreatedAt = DateTime.Now
                };

                db.MemberSecurityLogs.Add(log);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LogSecurityEvent 錯誤 : {ex.Message}");
            }
        }




        [HttpGet("security-logs")]
        [Authorize]
        public IActionResult GetSecurityLogs([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var account = User.FindFirstValue(ClaimTypes.Name);
            if (string.IsNullOrEmpty(account))
                return Unauthorized(new { message = "找不到登入資訊" });

            var member = _context.Members.FirstOrDefault(m => m.FAccount == account);
            if (member == null)
                return NotFound(new { message = "會員不存在" });

            var query = _context.MemberSecurityLogs
                .Where(log => log.FMemberId == member.FMemberId)
                .OrderByDescending(log => log.FCreatedAt)
                .Take(30);

            var totalCount = query.Count();
            var logs = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(log => new SecurityLogDto
                {
                    EventType = log.FEventType,
                    IpAddress = log.FIpAddress,
                    CreatedAt = log.FCreatedAt
                })
                .ToList();

            return Ok(new
            {
                totalCount,
                page,
                pageSize,
                logs
            });
        }

        private async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var smtpConfig = _config.GetSection("Smtp");
                var smtpHost = smtpConfig["Host"];
                var smtpPort = int.Parse(smtpConfig["Port"]);
                var smtpAccount = smtpConfig["Account"];
                var smtpPassword = smtpConfig["Password"];
                var fromName = smtpConfig["FromName"];

                var message = new System.Net.Mail.MailMessage();
                message.From = new System.Net.Mail.MailAddress(smtpAccount, fromName);
                message.To.Add(toEmail);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                using (var client = new System.Net.Mail.SmtpClient(smtpHost, smtpPort))
                {
                    client.Credentials = new System.Net.NetworkCredential(smtpAccount, smtpPassword);
                    client.EnableSsl = true;
                    await client.SendMailAsync(message);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"寄信錯誤: {ex.Message}");
                return false;
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.FEmail == dto.Email);
            if (member == null)
                return BadRequest(new { message = "查無此 Email" });

            // 組成前端的重設密碼連結（只帶 email，不帶 token）
            string resetLink = $"http://localhost:4200/show/reset-password?email={dto.Email}";

            string subject = "重設密碼通知";
            string body = $@"
                           <h3>親愛的 {member.FName}，您好：</h3>
                           <p>請點擊以下連結重設您的密碼：</p>
                           <p><a href='{resetLink}'>{resetLink}</a></p>
                           <p>若您沒有請求此操作，請忽略此信。</p>
                           ";

            await SendEmailAsync(dto.Email, subject, body);

            return Ok(new { message = "密碼重設連結已寄出，請查收您的信箱。" });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            if (dto.NewPassword != dto.ConfirmPassword)
                return BadRequest(new { message = "兩次密碼不一致" });

            var member = await _context.Members.FirstOrDefaultAsync(m => m.FEmail == dto.Email);
            if (member == null)
                return NotFound(new { message = "查無此帳號" });

            byte[] salt = GenerateSalt();
            string hashedPassword = HashPassword(dto.NewPassword, salt);

            member.FPasswordSalt = Convert.ToBase64String(salt);
            member.FPasswordHash = hashedPassword;

            await _context.SaveChangesAsync();

            return Ok(new { message = "密碼已成功重設" });
        }


    }
}
