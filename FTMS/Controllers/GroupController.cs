using FTMS.DTOs;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FTMS.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;
    private readonly IUserContextService _userContextService; 

    public GroupController(IGroupService groupService, IUserContextService userContextService)
    {
        _groupService = groupService;
        _userContextService = userContextService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateGroup([FromBody] GroupDto dto)
    {
        var userId = _userContextService.GetUserId();
        var result = await _groupService.CreateGroupAsync(dto, userId);
        return CreatedAtAction(nameof(GetGroupById), new { groupId = result.Id }, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGroups()
    {
        var groups = await _groupService.GetAllGroupsAsync();
        return Ok(groups);
    }

    [HttpGet("{groupId}")]
    public async Task<IActionResult> GetGroupById(int groupId)
    {
        var group = await _groupService.GetGroupByIdAsync(groupId);
        return group != null ? Ok(group) : NotFound();
    }

    [HttpPut("{groupId}")]
    [Authorize]
    public async Task<IActionResult> UpdateGroup(int groupId, [FromBody] GroupDto dto)
    {
        var userId = _userContextService.GetUserId();
        var success = await _groupService.UpdateGroupAsync(groupId, dto, userId);
        return success ? NoContent() : Forbid();
    }

    [HttpDelete("{groupId}")]
    [Authorize]
    public async Task<IActionResult> DeleteGroup(int groupId)
    {
        var userId = _userContextService.GetUserId();
        var success = await _groupService.DeleteGroupAsync(groupId, userId);
        return success ? NoContent() : Forbid();
    }
}

