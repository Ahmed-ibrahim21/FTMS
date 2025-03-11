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

        public async Task<GetReactionDto> AddReactionAsync(ReactionDto reactionDto)
        {
            var reaction = await _reactionRepository.AddReactionAsync(reactionDto);
            await _hubContext.Clients.All.SendAsync("ReceiveReaction", reaction); 
            return reaction;
        }

        public async Task<bool> RemoveReactionAsync(int reactionId)
        {
            var result = await _reactionRepository.RemoveReactionAsync(reactionId);
            if (result)
            {
                await _hubContext.Clients.All.SendAsync("RemoveReaction", reactionId);
            }
            return result;
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
