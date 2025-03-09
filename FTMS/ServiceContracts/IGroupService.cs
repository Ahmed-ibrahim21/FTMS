using FTMS.DTOs;

namespace FTMS.ServiceContracts;

public interface IGroupService
{
    Task<GetGroupDto> CreateGroupAsync(GroupDto dto, string userId);
    Task<IEnumerable<GetGroupDto>> GetAllGroupsAsync();
    Task<GetGroupDto?> GetGroupByIdAsync(int groupId);
    Task<bool> UpdateGroupAsync(int groupId, GroupDto dto, string userId);
    Task<bool> DeleteGroupAsync(int groupId, string userId);
}
