using FTMS.DTOs;
using FTMS.models.models_for_M_M;

namespace FTMS.ServiceContracts;

public interface IGroupService
{
    Task<GetGroupDto> CreateGroupAsync(GroupDto dto, string userId);
    Task<IEnumerable<GetGroupDto>> GetAllGroupsAsync();
    Task<GetGroupDto?> GetGroupByIdAsync(int groupId);
    Task<bool> UpdateGroupAsync(int groupId, GroupDto dto, string userId);
    Task<bool> DeleteGroupAsync(int groupId, string userId);

    //Group Membership
    Task<bool> RequestToJoinGroupAsync(string userId, int groupId);
    Task<bool> LeaveGroupAsync(string userId, int groupId);
    Task<bool> ApproveJoinRequestAsync(string adminId, int groupId, string userId);
    Task<bool> DenyJoinRequestAsync(string adminId, int groupId, string userId);
    Task<bool> RemoveMemberAsync(string adminId, int groupId, string userId);
    Task<bool> AssignRoleAsync(string adminId, int groupId, string userId, GroupRole newRole);
    Task<bool> IsGroupOwnerAsync(string userId, int groupId);
    Task<List<UserDto>> GetGroupMembersAsync(int groupId);
    Task<List<UserDto>> GetPendingGroupMembersAsync(int groupId);
}
