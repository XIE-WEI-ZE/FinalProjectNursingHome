namespace prjFinalProjectApi.Models.Dto
{
    // 前端送進來的欄位（白名單）
    public class RegistrationCreateDto
    {
        public int EventBatchId { get; set; }                 // 必填
        public int MemberId { get; set; }                     // 必填
        public decimal? AmountDue { get; set; }               // 可為空 (DECIMAL(10,0))
        public DateTime? RegistrationDateTime { get; set; }   // 不送就用 Now
        public int CurrentStatus { get; set; } = 1;           // 1=報名成功（依系統）
        public string? InternalRemarks { get; set; }          // 可為空(<=500字)
    }

    // 後端回傳給前端
    public class RegistrationResDto
    {
        public int RegistrationId { get; set; }
        public string RegistrationNum { get; set; } = string.Empty; // REGyyyyMMddnnn
    }
}
