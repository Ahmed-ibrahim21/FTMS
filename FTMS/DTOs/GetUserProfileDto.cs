using Microsoft.AspNetCore.Mvc;

namespace FTMS.DTOs
{
    public class GetUserProfileDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsApproved { get; set; } 

        [FromForm]
        public byte[]? ProfilePic { get; set; }

    }
}
