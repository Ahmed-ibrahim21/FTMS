using FTMS.models.models_for_M_M;
using System.Linq.Expressions;

namespace FTMS.RepositoriesContracts;

public interface IUserGroupRepository
{
    Task AddAsync(UserGroup userGroup);
    Task<bool> ExistsAsync(Expression<Func<UserGroup, bool>> predicate);
}
