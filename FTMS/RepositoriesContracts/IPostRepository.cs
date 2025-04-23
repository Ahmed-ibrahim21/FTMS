using FTMS.DTOs;
using FTMS.models;

namespace FTMS.RepositoriesContracts
    
{
    public interface IPostRepository
    {
        Task<GetPostDto> CreatePostAsync(PostDto postDto);
        Task<GetPostDto> UpdatePostAsync(int postId, UpdatePostDto postDto);
        Task<bool> DeletePostAsync(int postId);
        Task<GetPostDto> GetPostByIdAsync(int postId);
        Task<List<GetPostDto>> GetAllPostsAsync();
        Task<List<GetPostDto>> GetPostsByGroupIdAsync(int groupId);

        Task<List<GetPostDto>> GetPostsByUserIdAsync(string userId);
    }

}
