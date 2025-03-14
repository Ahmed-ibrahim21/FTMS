using FTMS.DTOs;
using FTMS.Hubs;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.SignalR;

namespace FTMS.Services
{
    public class ReactionService : IReactionService
    {
        private readonly IReactionRepository _reactionRepository;
        private readonly IHubContext<ReactionHub> _hubContext;

        public ReactionService(IReactionRepository reactionRepository, IHubContext<ReactionHub> hubContext)
        {
            _reactionRepository = reactionRepository;
            _hubContext = hubContext;
        }

        public async Task<int> AddReactionAsync(ReactionDto reactionDto)
        {
            int updatedCount = await _reactionRepository.AddReactionAsync(reactionDto);

            await _hubContext.Clients.Group($"Post_{reactionDto.PostId}")
                .SendAsync("UpdateLikeCount", reactionDto.PostId, updatedCount);

            return updatedCount;
        }

        public async Task<int> RemoveReactionAsync(int reactionId)
        {
            int updatedCount = await _reactionRepository.RemoveReactionAsync(reactionId);

            await _hubContext.Clients.Group($"Post_{reactionId}")
                .SendAsync("UpdateLikeCount", reactionId, updatedCount);

            return updatedCount;
        }

        public async Task<List<GetReactionDto>> GetReactionsByCommentIdAsync(int commentId)
        {
            return await _reactionRepository.GetReactionsByCommentIdAsync(commentId);
        }

        public async Task<List<GetReactionDto>> GetReactionsByPostIdAsync(int postId)
        {
            return await _reactionRepository.GetReactionsByPostIdAsync(postId);
        }
    }

}
