using FTMS.DTOs;
using FTMS.RepositoriesContracts;

namespace FTMS.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly FTMSContext _context;

        public ProfileRepository(FTMSContext context)
        {
            _context = context;
        }

        public async Task<GetUserProfileDto> GetProfileAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {userId} not found.");

            return new GetUserProfileDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePic = user.ProfilePic,
            };
        }

        public async Task<GetUserProfileDto> UpdateProfileAsync(string userId, UserProfileDto profileDto)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {userId} not found.");

            user.FirstName = profileDto.FirstName ?? user.FirstName;
            user.LastName = profileDto.LastName ?? user.LastName;
            if (profileDto.ProfilePic != null)
            {
                using var memoryStream = new MemoryStream();
                await profileDto.ProfilePic.CopyToAsync(memoryStream);
                user.ProfilePic = memoryStream.ToArray();
            }
            else
            {
                user.ProfilePic = user.ProfilePic;
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new GetUserProfileDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePic = user.ProfilePic
            };
        }
    }
}
