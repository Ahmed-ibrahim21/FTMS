using FTMS.models;
using FTMS.models.models_for_M_M;

namespace FTMS.RepositoriesContracts;

public interface IGroupRepository
{
    //Group Management
    Task<Group> CreateAsync(Group group);
    Task<IEnumerable<Group>> GetAllAsync();
    Task<Group?> GetByIdAsync(int groupId);
    Task<Group?> UpdateAsync(Group group);
    Task<bool> DeleteAsync(int groupId);
    //Group MemberShip
    Task<Group?> GetGroupByIdAsync(int groupId);
    Task<UserGroup?> GetUserGroupAsync(string userId, int groupId);
    Task<List<UserGroup>> GetGroupMembersAsync(int groupId);
    Task AddUserToGroupAsync(UserGroup userGroup);
    Task RemoveUserFromGroupAsync(UserGroup userGroup);
    Task UpdateUserGroupAsync(UserGroup userGroup);
    Task SaveChangesAsync();
}
