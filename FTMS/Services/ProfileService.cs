using FTMS.DTOs;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;

namespace FTMS.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<GetUserProfileDto> GetProfileAsync(string userId)
        {
            return await _profileRepository.GetProfileAsync(userId);
        }

        public async Task<GetUserProfileDto> UpdateProfileAsync(string userId, UserProfileDto profileDto)
        {
            return await _profileRepository.UpdateProfileAsync(userId, profileDto);
        }
    }
}
