using FTMS.DTOs;

namespace FTMS.RepositoriesContracts
{
    public interface IReactionRepository
    {
        Task<int> AddReactionAsync(ReactionDto reactionDto);
        Task<int> RemoveReactionAsync(int reactionId);
        Task<List<GetReactionDto>> GetReactionsByCommentIdAsync(int commentId);
        Task<List<GetReactionDto>> GetReactionsByPostIdAsync(int postId);
    }

}
