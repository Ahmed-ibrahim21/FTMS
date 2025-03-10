using FTMS.models.models_for_M_M;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FTMS.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class GroupMembershipController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupMembershipController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet("{groupId}/members")]
    public async Task<IActionResult> GetGroupMembers(int groupId)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized("User not authenticated");

        var members = await _groupService.GetGroupMembersAsync(groupId);
        return Ok(members);
    }

    [HttpGet("{groupId}/pending-members")]
    public async Task<IActionResult> GetPendingGroupMembers(int groupId)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized("User not authenticated");

        var isAdmin = User.IsInRole("Admin");
        var isOwner = await _groupService.IsGroupOwnerAsync(userId, groupId);

        if (!isAdmin && !isOwner)
            return Forbid("Only Admins or the Group Owner can view pending members.");

        var pendingMembers = await _groupService.GetPendingGroupMembersAsync(groupId);
        return Ok(pendingMembers);
    }

    [HttpPost("{groupId}/join")]
    public async Task<IActionResult> JoinGroup(int groupId)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var success = await _groupService.RequestToJoinGroupAsync(userId!, groupId);
        return success ? Ok("Request sent") : BadRequest("Already a member");
    }

    [HttpPost("{groupId}/leave")]
    public async Task<IActionResult> LeaveGroup(int groupId)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var success = await _groupService.LeaveGroupAsync(userId!, groupId);
        return success ? Ok("Left the group") : BadRequest("Not a member");
    }

    [HttpPut("{groupId}/approve-by-admin/{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ApproveRequestByAdmin(int groupId, string userId)
    {
        var adminId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var success = await _groupService.ApproveJoinRequestAsync(adminId!, groupId, userId);
        return success ? Ok("User approved") : BadRequest("Failed to approve");
    }

    [HttpPut("{groupId}/approve-by-owner/{userId}")]
    public async Task<IActionResult> ApproveRequest(int groupId, string userId)
    {
        var adminId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(adminId))
            return Unauthorized("User not authenticated");

        var isOwner = await _groupService.IsGroupOwnerAsync(adminId, groupId);
        if (!isOwner)
            return Forbid("Only the group owner can approve requests.");

        var success = await _groupService.ApproveJoinRequestAsync(adminId, groupId, userId);
        return success ? Ok("User approved") : BadRequest("Failed to approve");
    }

    [HttpPut("{groupId}/deny-by-owner/{userId}")]
    public async Task<IActionResult> DenyRequestByOwner(int groupId, string userId)
    {
        var ownerId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(ownerId))
            return Unauthorized("User not authenticated");

        var isOwner = await _groupService.IsGroupOwnerAsync(ownerId, groupId);
        if (!isOwner)
            return Forbid("Only the group owner can deny requests.");

        var success = await _groupService.DenyJoinRequestAsync(ownerId, groupId, userId);
        return success ? Ok("Join request denied") : BadRequest("Failed to deny request");
    }


    [HttpPut("{groupId}/deny-join/{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DenyJoinRequest(int groupId, string userId)
    {
        var adminId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var success = await _groupService.DenyJoinRequestAsync(adminId!, groupId, userId);
        return success ? Ok("Join request denied") : BadRequest("Failed to deny join request");
    }


    [HttpPut("{groupId}/assign-role/{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignRole(int groupId, string userId, [FromBody] GroupRole role)
    {
        var adminId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var success = await _groupService.AssignRoleAsync(adminId!, groupId, userId, role);
        return success ? Ok("Role assigned") : BadRequest("Failed to assign role");
    }
}
