using Microsoft.AspNetCore.Http;

using System;

namespace prjFinalProjectApi.Models.Dto
{
    public class UpdateMemberDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdNumber { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }

        
        public IFormFile? Photo { get; set; }
    }
}
