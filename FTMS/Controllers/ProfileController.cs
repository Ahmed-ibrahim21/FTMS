using FTMS.DTOs;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FTMS.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IUserContextService _userContextService;

        public ProfileController(IProfileService profileService, IUserContextService userContextService)
        {
            _profileService = profileService;
            _userContextService = userContextService;
        }


        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var userId = _userContextService.GetUserId();
            var profile = await _profileService.GetProfileAsync(userId);
            return Ok(profile);
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
