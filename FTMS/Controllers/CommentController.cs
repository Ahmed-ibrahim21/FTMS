using FTMS.DTOs;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FTMS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentDto commentDto)
        {
            var comment = await _commentService.CreateCommentAsync(commentDto);
            return CreatedAtAction(nameof(GetCommentById), new { commentId = comment.Id }, comment);
        }

        [HttpPut("{commentId}")]
        public async Task<IActionResult> UpdateComment(int commentId, [FromBody] CommentDto commentDto)
        {
            if (commentId <= 0)
                return BadRequest("Comment ID must be positive.");

            var updatedComment = await _commentService.UpdateCommentAsync(commentId, commentDto);
            return Ok(updatedComment);
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            await _commentService.DeleteCommentAsync(commentId);
            return NoContent();
        }

        [HttpGet("{commentId}")]
        public async Task<IActionResult> GetCommentById(int commentId)
        {
            var comment = await _commentService.GetCommentByIdAsync(commentId);
            return Ok(comment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentService.GetAllCommentsAsync();
            return Ok(comments);
        }
        [HttpGet("{PostId}")]
        public async Task<IActionResult> GetCommentsByPostId(int PostId)
        {
            var comments = await _commentService.GetCommentsByPostIdAsync(PostId);
            return Ok(comments);
        }
    }

}
