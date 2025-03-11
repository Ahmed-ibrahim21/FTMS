using FTMS.DTOs;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;

namespace FTMS.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<GetPostDto> CreatePostAsync(PostDto postDto)
        {
            return await _postRepository.CreatePostAsync(postDto);
        }

        public async Task<GetPostDto> UpdatePostAsync(int postId, PostDto postDto)
        {
            return await _postRepository.UpdatePostAsync(postId, postDto);
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            return await _postRepository.DeletePostAsync(postId);
        }

        public async Task<GetPostDto> GetPostByIdAsync(int postId)
        {
            return await _postRepository.GetPostByIdAsync(postId);
        }

        public async Task<List<GetPostDto>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllPostsAsync();
        }
    }

}
