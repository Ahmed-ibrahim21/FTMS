using FTMS.DTOs;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace FTMS.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile(string userId)
        {
            var profile = await _profileService.GetProfileAsync(userId);
            return Ok(profile);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateProfile(string userId,UserProfileDto profileDto)
        {
            var updatedProfile = await _profileService.UpdateProfileAsync(userId, profileDto);
            return Ok(updatedProfile);
        }
    }
}
