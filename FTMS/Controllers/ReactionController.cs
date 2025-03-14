using FTMS.DTOs;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FTMS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
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
            int updatedLikeCount = await _reactionService.AddReactionAsync(reactionDto);

            return Ok(new { postId = reactionDto.PostId, likeCount = updatedLikeCount });
        }


        [HttpDelete("{reactionId}")]
        public async Task<IActionResult> RemoveReaction(int reactionId)
        {
            int updatedLikeCount = await _reactionService.RemoveReactionAsync(reactionId);

            return Ok(new { reactionId, likeCount = updatedLikeCount });
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
