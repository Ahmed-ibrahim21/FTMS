using FTMS.DTOs;
using FTMS.models;
using FTMS.ServiceContracts;
using FTMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FTMS.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    private readonly UserManager<User> _userManager;


    public UsersController(IUserService service,UserManager<User> userManager)
    {
        _service = service;
        _userManager = userManager;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _service.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(string id)
    {
        var user = await _service.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(UserCreateDto dto)
    {
        var created = await _service.CreateAsync(dto);
        if (!created) return BadRequest("User creation failed.");
        return Ok("User created.");
    }
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UserDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return Ok("User updated.");
    }
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return Ok("User deleted.");
    }

    [HttpGet("by-username/{username}")]
    [Authorize]
    public async Task<IActionResult> GetByUsername(string username)
    {
        var user = await _service.GetByUsernameAsync(username);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpGet("by-email/{email}")]
    [Authorize]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var user = await _service.GetByEmailAsync(email);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpGet("search-by-name")]
    [Authorize]
    public async Task<IActionResult> SearchByName([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Search term is required.");

        var users = await _service.SearchByNameAsync(name);

        if (users == null || !users.Any())
            return NotFound("No users found with that name.");

        return Ok(users);
    }


    [HttpGet("users")]
    public async Task<IActionResult> GetRegularUsers()
    {
        var usersInRole = await _userManager.GetUsersInRoleAsync("User");
        var users = _service.MapUserToDto(usersInRole);
        return Ok(users);
    }


    [HttpGet("trainers")]
    public async Task<IActionResult> GetTrainers()
    {
        var usersInRole = await _userManager.GetUsersInRoleAsync("Trainer");
        var trainers = _service.MapUserToDto(usersInRole);
        return Ok(trainers);
    }

    
    [HttpGet("admin")]
    public async Task<IActionResult> GetAdmins()
    {
        var usersInRole = await _userManager.GetUsersInRoleAsync("Admin");
        var admins = _service.MapUserToDto(usersInRole);
        return Ok(admins);
    }

    [HttpGet("pending-trainers")]
    [Authorize(Roles = "Admin")]

    public async Task<IActionResult> GetPendingTrainers()
    {
        var usersInRole = await _userManager.GetUsersInRoleAsync("Trainer");
        var pendingTrainers = usersInRole.Where(u => u.IsApproved == false).ToList();
        var trainers = _service.MapUserToDto(null,pendingTrainers);
        return Ok(trainers);
    }

}
