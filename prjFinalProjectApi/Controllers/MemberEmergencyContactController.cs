using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prjFinalProjectApi.Models;
using System.Security.Claims;

namespace prjFinalProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // 必須登入才能使用
    public class MemberEmergencyContactController : ControllerBase
    {
        private readonly DbNursingHomeContext _context;

        public MemberEmergencyContactController(DbNursingHomeContext context)
        {
            _context = context;
        }

        /// 取得 JWT 當前登入會員 ID
        private int GetCurrentMemberId()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier)
                        ?? User.FindFirst("nameid")
                        ?? User.FindFirst("memberId")
                        ?? User.FindFirst("sub");

            if (claim == null || !int.TryParse(claim.Value, out var memberId))
                throw new UnauthorizedAccessException("無法取得登入會員 ID");

            return memberId;
        }

        /// 取得緊急聯絡人（前台查詢使用）
        [HttpGet("me")]
        public IActionResult GetMyEmergencyContact()
        {
            var memberId = GetCurrentMemberId();

            var contact = _context.MemberEmergencyContacts
                .FirstOrDefault(c => c.FMemberId == memberId && c.FIsActive == true);

            if (contact == null)
            {
                return NotFound(new { message = "尚未建立緊急聯絡人資料" });
            }

            
            return Ok(new
            {
                contact.FRelationship,
                contact.FContactName,
                contact.FPhone,
                contact.FEmail,
                contact.FCity,
                contact.FDistrict,
                contact.FAddress,
                contact.FNotes,
                contact.FIsPrimary,
                canEditContact = false // 前台一律不可編輯
            });
        }
    }
}
