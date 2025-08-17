using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjFinalProjectApi.Models;
using prjFinalProjectApi.Models.Dtos;
using System.Security.Claims;
namespace prjFinalProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthRecordController : ControllerBase
    {
        private readonly DbNursingHomeContext _context;
        public HealthRecordController(DbNursingHomeContext context)
        {
            _context = context;
        }

        [HttpGet("my-records")]
        [Authorize]
        public async Task<IActionResult> GetMyHealthRecords()
        { 
            var account = User.FindFirstValue(ClaimTypes.Name);
            if(string.IsNullOrEmpty(account))
                return Unauthorized(new { message = "找不到登入資訊" });
            var member = await _context.Members.
                FirstOrDefaultAsync(m => m.FAccount == account);
            if (member == null)
                return NotFound(new { message = "會員不存在" });
            var records = await _context.MemberDailyHealthRecords
                .Where(r => r.FMemberId == member.FMemberId)
                .OrderByDescending(r => r.FRecordDate)
                .Select(r => new HealthRecordDto
                {
                    RecordDate = r.FRecordDate.HasValue
                    ? r.FRecordDate.Value.ToDateTime(TimeOnly.MinValue)
                    : null,
                    Systolic = r.FSystolic,
                    Diastolic = r.FDiastolic,
                    Pulse = r.FPulse,
                    IORecord = r.FIorecord,
                    CheckPeriod = r.FCheckPeriod,
                    Notes = r.FNotes
                })
                .ToListAsync();
            return Ok(records);

        }
        
        
    }
}
