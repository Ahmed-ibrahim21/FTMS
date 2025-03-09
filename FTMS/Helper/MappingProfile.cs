using AutoMapper;
using FTMS.DTOs;
using FTMS.models;

namespace FTMS.Helper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Group, GetGroupDto>();
        CreateMap<GroupDto, Group>();
    }
}
