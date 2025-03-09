using FTMS.DTOs;
using FTMS.RepositoriesContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FTMS.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostDto postDto)
        {
            var post = await _postRepository.CreatePostAsync(postDto);
            return CreatedAtAction(nameof(GetPostById), new { postId = post.PostId }, post);
        }
        [Authorize]
        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(int postId, [FromBody] PostDto postDto)
        {
            if (postId <= 0)
                return BadRequest("Post ID must be positive.");

            var updatedPost = await _postRepository.UpdatePostAsync(postId,postDto);
            return Ok(updatedPost);
        }
        [Authorize]
        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            await _postRepository.DeletePostAsync(postId);
            return NoContent();
        }
        [Authorize]
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById(int postId)
        {
            var post = await _postRepository.GetPostByIdAsync(postId);
            return Ok(post);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return Ok(posts);
        }
    }

}
