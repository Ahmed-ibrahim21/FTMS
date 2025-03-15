using AutoMapper;
using FTMS.DTOs;
using FTMS.models;
using Microsoft.AspNetCore.Mvc;

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
        CreateMap<UpdatePostDto, Post>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.Video, opt => opt.Ignore())
                .ReverseMap();

        CreateMap<Post, GetPostDto>().ReverseMap();

        CreateMap<CommentDto, Comment>().ReverseMap();
        CreateMap<GetCommentDto, Comment>().ReverseMap();
        CreateMap<GetReactionDto, Reaction>().ReverseMap();
        CreateMap<ReactionDto, Reaction>().ReverseMap();
        CreateMap<UserProfileDto, User>()
                       .ForMember(dest => dest.ProfilePic, opt => opt.Ignore())
                       .ReverseMap();
        CreateMap<GetUserProfileDto, User>().ReverseMap();
        CreateMap<GetChatDto, Chat>().ReverseMap();
    }
}
