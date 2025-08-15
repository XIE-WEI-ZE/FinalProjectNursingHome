using Microsoft.AspNetCore.Http;

namespace prjFinalProjectApi.Models.Dtos
{
    public class RegisterDto
    {
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public DateTime? BirthDate { get; set; }

        // 大頭貼檔案（圖片上傳）
        public IFormFile? Photo { get; set; }
    }
}
