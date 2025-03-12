using FTMS.DTOs;
using FTMS.models;

namespace FTMS.ServiceContracts
{
    public interface IPostService
    {
        Task<GetPostDto> CreatePostAsync(PostDto postDto);
        Task<GetPostDto> UpdatePostAsync(int postId, UpdatePostDto postDto);
        Task<bool> DeletePostAsync(int postId);
        Task<GetPostDto> GetPostByIdAsync(int postId);
        Task<List<GetPostDto>> GetAllPostsAsync();
    }

}
