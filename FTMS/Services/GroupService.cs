using AutoMapper;
using FTMS.DTOs;
using FTMS.models;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;

namespace FTMS.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
   // private readonly IUserGroupRepository _userGroupRepository;
   // private readonly IGroupJoinRequestRepository _joinRequestRepository;
    private readonly IMapper _mapper;

    public GroupService(
        IGroupRepository groupRepository,
        //IUserGroupRepository userGroupRepository,
       // IGroupJoinRequestRepository joinRequestRepository,
        IMapper mapper)
    {
        _groupRepository = groupRepository;
        //_userGroupRepository = userGroupRepository;
       // _joinRequestRepository = joinRequestRepository;
        _mapper = mapper;
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
}