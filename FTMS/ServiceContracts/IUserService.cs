using FTMS.DTOs;
using FTMS.models;

namespace FTMS.ServiceContracts;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(string id);
    Task<bool> CreateAsync(UserCreateDto dto);
    Task<bool> UpdateAsync(string id, UserDto dto);
    Task<bool> DeleteAsync(string id);
    Task<UserDto?> GetByUsernameAsync(string username);
    Task<UserDto?> GetByEmailAsync(string email);
    Task<List<UserDto>> SearchByNameAsync(string name);

    List<UserDto> MapUserToDto(IList<User> users = null, List<User> users1 = null);

}
