namespace prjFinalProjectApi.Models.Dtos
{
    public class HealthRecordDto
    {
        public DateTime? RecordDate { get; set; }     
        public int? Systolic { get; set; }            
        public int? Diastolic { get; set; }
        public int? Pulse { get; set; }
        public string? IORecord { get; set; }
        public string? CheckPeriod { get; set; }
        public string? Notes { get; set; }
    }

}
