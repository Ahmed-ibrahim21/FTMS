using FTMS.DTOs;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FTMS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] PostDto postDto)
        {
            var post = await _postService.CreatePostAsync(postDto);
            return CreatedAtAction(nameof(GetPostById), new { postId = post.PostId }, post);
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(int postId, [FromForm] UpdatePostDto postDto)
        {
            if (postId <= 0)
                return BadRequest("Post ID must be positive.");

            var updatedPost = await _postService.UpdatePostAsync(postId, postDto);
            return Ok(updatedPost);
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            await _postService.DeletePostAsync(postId);
            return NoContent();
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById(int postId)
        {
            var post = await _postService.GetPostByIdAsync(postId);
            return Ok(post);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }
        [HttpGet("{groupId}")]
        public async Task<IActionResult> GetAllPosts(int groupId)
        {
            var posts = await _postService.GetPostsByGroupIdAsync(groupId);
            return Ok(posts);
        }
    }


}
