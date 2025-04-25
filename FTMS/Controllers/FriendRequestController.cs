using FTMS.DTOs;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FTMS.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FriendRequestController : ControllerBase
{
    private readonly IFriendRequestService _service;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public FriendRequestController(IFriendRequestService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendFriendRequest([FromBody] CreateFriendRequestDto requestDto)
    {
        var senderId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(senderId))
            return Unauthorized();

        var result = await _service.SendRequestAsync(senderId, requestDto);

        return Ok(result);
    }

    [HttpPut("accept/{id}")]
    public async Task<IActionResult> AcceptFriendRequest(int id)
    {
        await _service.AcceptRequestAsync(id);
        return NoContent();
    }

    [HttpPut("reject/{id}")]
    public async Task<IActionResult> RejectFriendRequest(int id)
    {
        await _service.RejectRequestAsync(id);
        return NoContent();
    }

    [HttpDelete("cancel/{id}")]
    public async Task<IActionResult> CancelFriendRequest(int id)
    {
        await _service.CancelRequestAsync(id);
        return NoContent();
    }

    [HttpGet("received")]
    public async Task<IActionResult> GetReceivedFriendRequests()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var result = await _service.GetReceivedRequestsAsync(userId);
        return Ok(result);
    }

    [HttpGet("sent")]
    public async Task<IActionResult> GetSentFriendRequests()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var result = await _service.GetSentRequestsAsync(userId);
        return Ok(result);
    }
    [HttpGet("GetAllFriends")]
    public async Task<IActionResult> GetAllFriends()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var result = await _service.GetAllFriendsAsync(userId);
        return Ok(result);
    }



}