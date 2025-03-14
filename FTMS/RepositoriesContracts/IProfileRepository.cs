using FTMS.DTOs;

namespace FTMS.RepositoriesContracts
{
    public interface IProfileRepository
    {
        Task<GetUserProfileDto> GetProfileAsync(string userId);
        Task<GetUserProfileDto> UpdateProfileAsync(string userId, UserProfileDto profileDto);
    }
}
