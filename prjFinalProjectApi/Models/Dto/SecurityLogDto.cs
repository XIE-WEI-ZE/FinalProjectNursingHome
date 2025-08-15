namespace prjFinalProjectApi.Models.Dtos
{
    public class SecurityLogDto
    {
        public string? EventType { get; set; }
        public string? IpAddress { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
