using FTMS.models.models_for_M_M;
using FTMS.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FTMS.Repositories;

public class UserGroupRepository: IUserGroupRepository
{
    private readonly FTMSContext _context;

    public UserGroupRepository(FTMSContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UserGroup userGroup)
    {
        await _context.UserGroups.AddAsync(userGroup);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Expression<Func<UserGroup, bool>> predicate)
    {
        return await _context.UserGroups.AnyAsync(predicate);
    }
}
