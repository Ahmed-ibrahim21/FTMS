using FTMS.DTOs;

namespace FTMS.ServiceContracts
{
    public interface IReactionService
    {
        Task<GetReactionDto> AddReactionAsync(ReactionDto reactionDto);
        Task<bool> RemoveReactionAsync(int reactionId);
        Task<List<GetReactionDto>> GetReactionsByCommentIdAsync(int commentId);
        Task<List<GetReactionDto>> GetReactionsByPostIdAsync(int postId);
    }

}
