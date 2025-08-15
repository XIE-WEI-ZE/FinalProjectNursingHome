namespace prjFinalProjectApi.Dtos
{
    public class MemberDto
    {
        public int MemberId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? IdNumber { get; set; }
        public string? Gender { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
