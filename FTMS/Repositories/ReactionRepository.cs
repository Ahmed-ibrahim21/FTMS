using AutoMapper;
using FTMS.DTOs;
using FTMS.models;
using FTMS.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FTMS.Repositories
{
    public class ReactionRepository : IReactionRepository
    {
        private readonly FTMSContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReactionRepository(FTMSContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> AddReactionAsync(ReactionDto reactionDto)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            var reaction = new Reaction
            {
                Type = reactionDto.Type,
                UserId = userId,
                CommentId = reactionDto.CommentId,
                PostId = reactionDto.PostId
            };

            _context.Reactions.Add(reaction);
            await _context.SaveChangesAsync();
            int updatedLikeCount = await _context.Reactions
        .Where(r => r.PostId == reactionDto.PostId)
        .CountAsync();
            return updatedLikeCount;
        }

        public async Task<int> RemoveReactionAsync(int reactionId)
        {
            var reaction = await _context.Reactions.FindAsync(reactionId);
            if (reaction == null)
                throw new KeyNotFoundException($"Reaction with ID {reactionId} not found.");

            _context.Reactions.Remove(reaction);
            await _context.SaveChangesAsync();
            int updatedLikeCount = await _context.Reactions
                    .Where(r => r.PostId == reaction.PostId)
                    .CountAsync(); 

            return updatedLikeCount;
        }

        public async Task<List<GetReactionDto>> GetReactionsByCommentIdAsync(int commentId)
        {
            var reactions = await _context.Reactions.Where(r => r.CommentId == commentId).ToListAsync();
            return _mapper.Map<List<GetReactionDto>>(reactions);
        }

        public async Task<List<GetReactionDto>> GetReactionsByPostIdAsync(int postId)
        {
            var reactions = await _context.Reactions.Where(r => r.PostId == postId).ToListAsync();
            return _mapper.Map<List<GetReactionDto>>(reactions);
        }
    }

}
