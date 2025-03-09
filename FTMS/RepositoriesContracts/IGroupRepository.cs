using FTMS.models;

namespace FTMS.RepositoriesContracts;

public interface IGroupRepository
{
    Task<Group> CreateAsync(Group group);
    Task<IEnumerable<Group>> GetAllAsync();
    Task<Group?> GetByIdAsync(int groupId);
    Task<Group?> UpdateAsync(Group group);
    Task<bool> DeleteAsync(int groupId);
}
