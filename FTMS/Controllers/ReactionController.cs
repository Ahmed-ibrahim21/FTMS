using FTMS.DTOs;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FTMS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReactionController : ControllerBase
    {
        private readonly IReactionService _reactionService;

        public ReactionController(IReactionService reactionService)
        {
            _reactionService = reactionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddReaction([FromBody] ReactionDto reactionDto)
        {
            var reaction = await _reactionService.AddReactionAsync(reactionDto);
            return CreatedAtAction(nameof(GetReactionsByComment), new { commentId = reaction.CommentId }, reaction);
        }

        [HttpDelete("{reactionId}")]
        public async Task<IActionResult> RemoveReaction(int reactionId)
        {
            await _reactionService.RemoveReactionAsync(reactionId);
            return NoContent();
        }

        [HttpGet("comment/{commentId}")]
        public async Task<IActionResult> GetReactionsByComment(int commentId)
        {
            var reactions = await _reactionService.GetReactionsByCommentIdAsync(commentId);
            return Ok(reactions);
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetReactionsByPost(int postId)
        {
            var reactions = await _reactionService.GetReactionsByPostIdAsync(postId);
            return Ok(reactions);
        }
    }

}
