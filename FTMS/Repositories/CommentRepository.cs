using AutoMapper;
using FTMS.DTOs;
using FTMS.models;
using FTMS.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FTMS.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly FTMSContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentRepository(FTMSContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetCommentDto> CreateCommentAsync(CommentDto commentDto)
        {
            if (commentDto == null)
                throw new ArgumentNullException(nameof(commentDto), "Comment data cannot be null.");

            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            var postExists = await _context.posts.AnyAsync(p => p.Id == commentDto.PostId);
            if (!postExists)
                throw new KeyNotFoundException($"Post with ID {commentDto.PostId} not found.");

            var comment = new Comment
            {
                Text = commentDto.Text,
                TimeStamp = DateTime.UtcNow,
                UserId = userId,
                PostId = commentDto.PostId
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetCommentDto>(comment);
        }

        public async Task<GetCommentDto> UpdateCommentAsync(int commentId, CommentDto commentDto)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
                throw new KeyNotFoundException($"Comment with ID {commentId} not found.");

            comment.Text = commentDto.Text ?? comment.Text;
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetCommentDto>(comment);
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
                throw new KeyNotFoundException($"Comment with ID {commentId} not found.");

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<GetCommentDto> GetCommentByIdAsync(int commentId)
        {
            var comment = await _context.Comments
                .Include(c => c.User)  
                .Include(c => c.Post)  
                .FirstOrDefaultAsync(c => c.Id == commentId);

            if (comment == null)
                throw new KeyNotFoundException($"Comment with ID {commentId} not found.");

            return _mapper.Map<GetCommentDto>(comment);
        }

        public async Task<List<GetCommentDto>> GetAllCommentsAsync()
        {
            var comments = await _context.Comments
                .Include(c => c.User)
                .Include(c => c.Post)
                .ToListAsync();

            return _mapper.Map<List<GetCommentDto>>(comments);
        }

        public async Task<List<GetCommentDto>> GetCommentsByPostIdAsync(int postId)
        {
            var comments = await _context.Comments
                .Where(c => c.PostId == postId)
                .Include(c => c.User)
                .OrderByDescending(c => c.TimeStamp)
                .ToListAsync();

            return _mapper.Map<List<GetCommentDto>>(comments);
        }
    }
}
