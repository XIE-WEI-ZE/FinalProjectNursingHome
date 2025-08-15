using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjFinalProjectApi.Helpers;
using prjFinalProjectApi.Models;
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
        public IActionResult Login([FromBody] LoginDto dto)
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
                //Console.WriteLine("=== GoogleLogin ===");
                //Console.WriteLine("Raw idToken: " + json.GetRawText());

                var idToken = json.GetRawText().Trim('"');

                var payload = await Google.Apis.Auth.GoogleJsonWebSignature.ValidateAsync(idToken);
                //Console.WriteLine($"Google 驗證成功：{payload.Email} - {payload.Name}");

                var email = payload.Email;
                var name = payload.Name;
                var externalId = payload.Subject;

                var member = await _context.Members
                    .FirstOrDefaultAsync(m => m.FEmail == email && m.FLoginProvider == "Google");

                if (member == null)
                {
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
                    //Console.WriteLine("新增 Google 使用者：" + member.FEmail);
                }

                var token = JwtHelper.GenerateToken(
                    member.FMemberId,
                    member.FAccount,
                    member.FEmail,
                    _config["Jwt:Key"],
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    60
                );

                //  登入成功記錄（含 IP）
                await LogSecurityEvent(member.FMemberId, "LoginSuccess", "Google 登入成功");

                return Ok(new
                {
                    token,
                    message = "Google 登入成功",
                    memberId = member.FMemberId
                });
            }
            catch (Exception ex)
            {
                //  登入失敗也記錄（memberId 不知道就放 null）
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

                //  裁切欄位長度（避免超過 DB 欄位長度）
                eventType = string.IsNullOrEmpty(eventType) ? null :
                            eventType.Length > 50 ? eventType.Substring(0, 50) : eventType;

                notes = string.IsNullOrEmpty(notes) ? null :
                        notes.Length > 200 ? notes.Substring(0, 200) : notes;

                ip = string.IsNullOrEmpty(ip) ? null :
                     ip.Length > 200 ? ip.Substring(0, 200) : ip;

                var log = new MemberSecurityLog
                {
                    FMemberId = memberId,
                    FEventType = eventType,
                    FNotes = notes,
                    FIpAddress = ip,
                    FCreatedAt = DateTime.Now
                };

                _context.MemberSecurityLogs.Add(log);
                await _context.SaveChangesAsync();
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


    }
}
