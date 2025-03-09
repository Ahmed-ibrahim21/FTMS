using FTMS.models;
using FTMS.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace FTMS.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly FTMSContext _context;

    public GroupRepository(FTMSContext context)
    {
        _context = context;
    }

    public async Task<Group> CreateAsync(Group group)
    {
        _context.Groups.Add(group);
        await _context.SaveChangesAsync();
        return group;
    }

    public async Task<IEnumerable<Group>> GetAllAsync()
    {
        return await _context.Groups.Include(g => g.UserGroups).ToListAsync();
    }

    public async Task<Group?> GetByIdAsync(int groupId)
    {
        return await _context.Groups
            .Include(g => g.UserGroups)
            .FirstOrDefaultAsync(g => g.Id == groupId);
    }

    public async Task<Group?> UpdateAsync(Group group)
    {
        _context.Groups.Update(group);
        await _context.SaveChangesAsync();
        return group;
    }

    public async Task<bool> DeleteAsync(int groupId)
    {
        var group = await _context.Groups.FindAsync(groupId);
        if (group == null) return false;

        _context.Groups.Remove(group);
        await _context.SaveChangesAsync();
        return true;
    }
}