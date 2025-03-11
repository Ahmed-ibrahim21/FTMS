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
        CreateMap<PostDto, Post>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.Video, opt => opt.Ignore())
                .ReverseMap();

        CreateMap<Post, GetPostDto>().ReverseMap();
        CreateMap<CreateReactionDto, Reaction>();
        CreateMap<Reaction, ReactionDto>();

        CreateMap<CommentDto, Comment>().ReverseMap();
        CreateMap<GetCommentDto, Comment>().ReverseMap();
    }
}
