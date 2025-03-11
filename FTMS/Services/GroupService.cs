using AutoMapper;
using FTMS.DTOs;
using FTMS.models;
using FTMS.models.models_for_M_M;
using FTMS.Repositories;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;

namespace FTMS.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;
    private readonly IUserGroupRepository _userGroupRepository;
    public GroupService(
        IGroupRepository groupRepository,
        IMapper mapper,
        IUserGroupRepository userGroupRepository)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
        _userGroupRepository = userGroupRepository;
    }

    public async Task<GetGroupDto> CreateGroupAsync(GroupDto dto, string userId)
    {
        var group = new Group
        {
            GroupName = dto.GroupName,
            Description = dto.Description,
            IsPrivate = dto.IsPrivate,
            CreatedByUserId = userId
        };

        var createdGroup = await _groupRepository.CreateAsync(group);
        var userGroup = new UserGroup
        {
            UserId = userId,
            GroupId = createdGroup.Id,
            Role = GroupRole.Owner
        };
        await _userGroupRepository.AddAsync(userGroup); 
        return _mapper.Map<GetGroupDto>(createdGroup);
    }


    public async Task<IEnumerable<GetGroupDto>> GetAllGroupsAsync()
    {
        var groups = await _groupRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GetGroupDto>>(groups);
    }

    public async Task<GetGroupDto?> GetGroupByIdAsync(int groupId)
    {
        var group = await _groupRepository.GetByIdAsync(groupId);
        return group == null ? null : _mapper.Map<GetGroupDto>(group);
    }

    public async Task<bool> UpdateGroupAsync(int groupId, GroupDto dto, string userId)
    {
        var group = await _groupRepository.GetByIdAsync(groupId);
        if (group == null) return false;

        group.GroupName = dto.GroupName;
        group.Description = dto.Description;
        group.IsPrivate = dto.IsPrivate;

        await _groupRepository.UpdateAsync(group);
        return true;
    }

    public async Task<bool> DeleteGroupAsync(int groupId, string userId)
    {
        var group = await _groupRepository.GetByIdAsync(groupId);
        if (group == null) return false;

        return await _groupRepository.DeleteAsync(groupId);
    }

    public async Task<bool> RequestToJoinGroupAsync(string userId, int groupId)
    {
        var group = await _groupRepository.GetGroupByIdAsync(groupId);
        if (group == null) return false;

        var existingMembership = await _groupRepository.GetUserGroupAsync(userId, groupId);
        if (existingMembership != null && existingMembership.Status != RequestStatus.Denied)
            return false; 

        var userGroup = new UserGroup
        {
            UserId = userId,
            GroupId = groupId,
            Role = GroupRole.Member,  
            Status = RequestStatus.Pending 
        };

        await _groupRepository.AddUserToGroupAsync(userGroup);
        await _groupRepository.SaveChangesAsync();
        return true;
    }


    public async Task<bool> LeaveGroupAsync(string userId, int groupId)
    {
        var membership = await _groupRepository.GetUserGroupAsync(userId, groupId);
        if (membership == null) return false;

        await _groupRepository.RemoveUserFromGroupAsync(membership);
        await _groupRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ApproveJoinRequestAsync(string adminId, int groupId, string userId)
    {
        var membership = await _groupRepository.GetUserGroupAsync(userId, groupId);
        if (membership == null || membership.Status != RequestStatus.Pending) return false;

        membership.Status = RequestStatus.Approved; 
        await _groupRepository.UpdateUserGroupAsync(membership);
        await _groupRepository.SaveChangesAsync();
        return true;
    }


    public async Task<bool> DenyJoinRequestAsync(string adminId, int groupId, string userId)
    {
        var membership = await _groupRepository.GetUserGroupAsync(userId, groupId);
        if (membership == null || membership.Status != RequestStatus.Pending) return false;

        membership.Status = RequestStatus.Denied; 
        await _groupRepository.UpdateUserGroupAsync(membership);
        await _groupRepository.SaveChangesAsync();
        return true;
    }
    public async Task<bool> RemoveMemberAsync(string adminId, int groupId, string userId)
    {
        var membership = await _groupRepository.GetUserGroupAsync(userId, groupId);
        if (membership == null) return false;

        await _groupRepository.RemoveUserFromGroupAsync(membership);
        await _groupRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AssignRoleAsync(string adminId, int groupId, string userId, GroupRole newRole)
    {
        var membership = await _groupRepository.GetUserGroupAsync(userId, groupId);
        if (membership == null) return false;

        membership.Role = newRole;
        await _groupRepository.UpdateUserGroupAsync(membership);
        await _groupRepository.SaveChangesAsync();
        return true;
    }
    public async Task<bool> IsGroupOwnerAsync(string userId, int groupId)
    {
        return await _userGroupRepository.ExistsAsync(ug =>
            ug.UserId == userId && ug.GroupId == groupId && ug.Role == GroupRole.Owner);
    }

    public async Task<List<UserDto>> GetGroupMembersAsync(int groupId)
    {
        var group = await _groupRepository.GetByIdAsync(groupId);
        if (group == null)
            return new List<UserDto>();

        var members = group.UserGroups!
        .Where(ug => ug.Status == RequestStatus.Approved)  
        .Select(ug => new UserDto
        {
            Id = ug.User!.Id,
            FirstName = ug.User.FirstName!, 
            LastName = ug.User.LastName!, 
            Email = ug.User!.Email!
        }).ToList();

        return members;
    }

    public async Task<List<UserDto>> GetPendingGroupMembersAsync(int groupId)
    {
        var group = await _groupRepository.GetByIdAsync(groupId);
        if (group == null)
            return new List<UserDto>();

        var pendingMembers = group.UserGroups!
            .Where(ug => ug.Status == RequestStatus.Pending)  
            .Select(ug => new UserDto
            {
                Id = ug.User!.Id,
                FirstName = ug.User.FirstName!,
                LastName = ug.User.LastName!,
                Email = ug.User!.Email!
            }).ToList();

        return pendingMembers;
    }

}
