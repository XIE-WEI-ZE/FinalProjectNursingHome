using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjFinalProjectApi.Models;
using prjFinalProjectApi.Models.Dto;
using System.Security.Claims;

namespace prjFinalProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly DbNursingHomeContext _context;
        private readonly IWebHostEnvironment _env;

        public MemberController(DbNursingHomeContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentMember()
        {
            var account = User.FindFirstValue(ClaimTypes.Name);
            if (string.IsNullOrEmpty(account))
                return Unauthorized(new { message = "找不到登入資訊" });

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.FAccount == account);

            if (member == null)
                return NotFound(new { message = "會員不存在" });

            //  防呆補上正確路徑
            string path = member.FProfilePictureUrl ?? "";
            if (!string.IsNullOrEmpty(path) && !path.StartsWith("images/members/"))
            {
                path = $"images/members/{path}";
            }

            //  拼接完整圖片網址
            string photoUrl = string.IsNullOrEmpty(path)
                ? $"{Request.Scheme}://{Request.Host}/images/members/user.png"
                : $"{Request.Scheme}://{Request.Host}/{path.TrimStart('/')}";

            return Ok(new
            {
                username = member.FAccount,
                name = member.FName,
                email = member.FEmail,
                phone = member.FPhone,
                idNumber = member.FIdNumber,
                gender = member.FGender,
                birthDate = member.FBirthDate?.ToString("yyyy-MM-dd"),
                photoUrl,
                residesInCareHome = member.FResidesInCareHomeStatus  
            });
        }


        // 更新會員資料
        [HttpPut("update")]
        [Authorize]
        public IActionResult UpdateMember([FromForm] UpdateMemberDto dto)
        {
            try
            {
                var account = User.FindFirstValue(ClaimTypes.Name);
                if (string.IsNullOrEmpty(account))
                    return Unauthorized(new { message = "找不到登入會員" });

                var member = _context.Members.FirstOrDefault(m => m.FAccount == account);
                if (member == null)
                    return NotFound(new { message = "會員不存在" });

                member.FName = dto.Name;
                member.FEmail = dto.Email;
                member.FPhone = dto.Phone;
                member.FIdNumber = dto.IdNumber;
                member.FGender = dto.Gender;

                if (dto.BirthDate.HasValue)
                    member.FBirthDate = DateOnly.FromDateTime(dto.BirthDate.Value);

                // 只有有上傳新圖片才更新頭像
                if (dto.Photo != null && dto.Photo.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "images", "members");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Photo.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        dto.Photo.CopyTo(stream);
                    }

                    // 要補完整資料夾路徑
                    member.FProfilePictureUrl = $"images/members/{uniqueFileName}";
                }


                _context.SaveChanges();

                return Ok(new { message = "會員資料更新成功" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "更新失敗", error = ex.Message });
            }
        }

    }
}
