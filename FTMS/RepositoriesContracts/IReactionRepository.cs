using FTMS.DTOs;

namespace FTMS.RepositoriesContracts
{
    public interface IReactionRepository
    {
        Task<GetReactionDto> AddReactionAsync(ReactionDto reactionDto);
        Task<bool> RemoveReactionAsync(int reactionId);
        Task<List<GetReactionDto>> GetReactionsByCommentIdAsync(int commentId);
        Task<List<GetReactionDto>> GetReactionsByPostIdAsync(int postId);
    }

}
