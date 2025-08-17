using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjFinalProjectApi.Models;
using prjFinalProjectApi.Models.Dto;

namespace prjFinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/EventRegistration")] // => /api/EventTemplate

    public class EventRegistrationController : Controller
    {
        private readonly DbNursingHomeContext _db;

        public EventRegistrationController(DbNursingHomeContext db) => _db = db;

        /// <summary>建立報名明細（回傳 RegistrationId / RegistrationNum）</summary>
        [HttpPost]
        public async Task<ActionResult<RegistrationResDto>> Create([FromBody] RegistrationCreateDto dto)
        {
            if (dto.EventBatchId <= 0 || dto.MemberId <= 0)
                return BadRequest(new { message = "EventBatchId 與 MemberId 為必填且需大於 0" });

            var now = dto.RegistrationDateTime ?? DateTime.Now;

            // 準備 entity（不含 RegistrationNum，待產生）
            var entity = new RegistrationDetail
            {
                EventBatchId = dto.EventBatchId,
                MemberId = dto.MemberId,
                AmountDue = dto.AmountDue,
                RegistrationDateTime = now,
                CurrentStatus = dto.CurrentStatus,
                InternalRemarks = dto.InternalRemarks
            };

            // 產生 RegistrationNum：REG + yyyyMMdd + 3位流水（001 起）
            var ymd = now.ToString("yyyyMMdd");
            var prefix = $"REG{ymd}";

            const int maxAttempts = 3; // 撞號重試（需配合唯一索引更安全）
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                // 今日筆數 + 1（簡易法）
                var todayCount = await _db.RegistrationDetails
                    .CountAsync(x => x.RegistrationNum.StartsWith(prefix));

                entity.RegistrationNum = $"{prefix}{(todayCount + 1):000}";
                _db.RegistrationDetails.Add(entity);

                try
                {
                    await _db.SaveChangesAsync();
                    return Ok(new RegistrationResDto
                    {
                        RegistrationId = entity.RegistrationId,
                        RegistrationNum = entity.RegistrationNum
                    });
                }
                catch (DbUpdateException)
                {
                    // 可能撞到唯一索引（高併發），重試
                    _db.Entry(entity).State = EntityState.Detached;

                    if (attempt == maxAttempts)
                        return StatusCode(409, new { message = "產生報名編號失敗，請稍後再試。" });

                    await Task.Delay(Random.Shared.Next(10, 50));
                    // 重新 new，避免追蹤狀態殘留
                    entity = new RegistrationDetail
                    {
                        EventBatchId = dto.EventBatchId,
                        MemberId = dto.MemberId,
                        AmountDue = dto.AmountDue,
                        RegistrationDateTime = now,
                        CurrentStatus = dto.CurrentStatus,
                        InternalRemarks = dto.InternalRemarks
                    };
                }
            }

            return StatusCode(500, new { message = "未知錯誤" });
        }


    }
}


//測試資料
//    {
//  "eventBatchId": 1001,
//  "memberId": 15,
//  "amountDue": 300,
//  "registrationDateTime": "2025-08-17T10:00:00",
//  "currentStatus": 1,
//  "internalRemarks": "前台報名"
//}