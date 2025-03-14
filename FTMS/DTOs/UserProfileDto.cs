using Microsoft.AspNetCore.Mvc;

namespace FTMS.DTOs
{
    public class UserProfileDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [FromForm]
        public IFormFile? ProfilePic { get; set; }
    }
}
