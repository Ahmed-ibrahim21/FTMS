using FTMS.DTOs;
using FTMS.models;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FTMS.Services;

public class UserService:IUserService
{
    private readonly IUserRepository _repo;
    private readonly UserManager<User> _userManager;

    public UserService(IUserRepository repo, UserManager<User> userManager)
    {
        _repo = repo;
        _userManager = userManager;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _repo.GetAllAsync();
        return users.Select(u => new UserDto
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email
        });
    }

    public async Task<UserDto?> GetByIdAsync(string id)
    {
        var user = await _repo.GetByIdAsync(id);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
    }

    public async Task<bool> CreateAsync(UserCreateDto dto)
    {
        var user = new User
        {
            Email = dto.Email,
            UserName = dto.UserName,
            FirstName = dto.FirstName,
            LastName = dto.LastName
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        return result.Succeeded;
    }

    public async Task<bool> UpdateAsync(string id, UserDto dto)
    {
        var user = await _repo.GetByIdAsync(id);
        if (user == null) return false;

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;

        _repo.Update(user);
        return await _repo.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var user = await _repo.GetByIdAsync(id);
        if (user == null) return false;

        _repo.Delete(user);
        return await _repo.SaveChangesAsync();
    }

    public async Task<UserDto?> GetByUsernameAsync(string username)
    {
        var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.UserName == username);

        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,

        };
    }

    public async Task<UserDto?> GetByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,

        };
    }

}
