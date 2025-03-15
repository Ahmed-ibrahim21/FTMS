using FTMS.DTOs;

namespace FTMS.ServiceContracts
{
    public interface IProfileService
    {
        Task<GetUserProfileDto> GetProfileAsync(string userId);
        Task<GetUserProfileDto> UpdateProfileAsync(string userId, UserProfileDto profileDto);
    }
}
