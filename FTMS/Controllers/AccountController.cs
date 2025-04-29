using FTMS.DTOs;
using FTMS.models;
using FTMS.ServiceContracts;
using FTMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FTMS.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly JwtService _jwtService;
    private readonly IUserService _userService;

    public AccountController(UserManager<User> userManager, JwtService jwtService, IUserService userService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            return Unauthorized("Invalid credentials");

        var roles = await _userManager.GetRolesAsync(user);

        if (roles.Contains("Trainer") && !user.IsApproved)
            return Unauthorized("Trainer account is pending approval by an admin.");

        var token = _jwtService.GenerateToken(user.Id, user.Email!, roles);

        return Ok(new { Token = token });
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        if (model.Role != "User" && model.Role != "Trainer")
            return BadRequest("Invalid role. You can only register as 'User' or 'Trainer'.");

        var existingUser = await _userManager.FindByEmailAsync(model.Email);
        if (existingUser != null)
            return BadRequest("Email is already in use.");

        var user = new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            UserName = model.Email,
            IsApproved = model.Role == "Trainer" ? false : true
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        await _userManager.AddToRoleAsync(user, model.Role);

        var message = model.Role == "Trainer"
        ? "Registration successful. Trainers require admin approval."
        : "Registration successful.";

        return Ok(new { Message = message });
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("approve-trainer/{userId}")]
    public async Task<IActionResult> ApproveTrainer(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return NotFound("User not found.");

        var roles = await _userManager.GetRolesAsync(user);
        if (!roles.Contains("Trainer"))
            return BadRequest("User is not a trainer.");

        user.IsApproved = true;
        await _userManager.UpdateAsync(user);

        return Ok(new { Message = "Trainer approved successfully." });
    }

    [HttpPost("change-password")]
    [Authorize(Roles = "Admin,User,Trainer")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
            return NotFound("User not found.");

        var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(new { Message = "Password changed successfully." });
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("reject-trainer/{userId}")]
    public async Task<IActionResult> RejectTrainer(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return NotFound("User not found.");

        var roles = await _userManager.GetRolesAsync(user);
        if (!roles.Contains("Trainer"))
            return BadRequest("User is not a trainer.");

        if (user.IsApproved)
            return BadRequest("User Is Already Accepted");

        await _userService.DeleteAsync(userId);

        return Ok(new { Message = "Trainer Rejected successfully." });
    }
}


