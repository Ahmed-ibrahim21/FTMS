using FTMS.DTOs;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;

namespace FTMS.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GetCommentDto> CreateCommentAsync(CommentDto commentDto)
        {
            return await _commentRepository.CreateCommentAsync(commentDto);
        }

        public async Task<GetCommentDto> UpdateCommentAsync(int commentId, CommentDto commentDto)
        {
            return await _commentRepository.UpdateCommentAsync(commentId, commentDto);
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            return await _commentRepository.DeleteCommentAsync(commentId);
        }

        public async Task<GetCommentDto> GetCommentByIdAsync(int commentId)
        {
            return await _commentRepository.GetCommentByIdAsync(commentId);
        }

        public async Task<List<GetCommentDto>> GetAllCommentsAsync()
        {
            return await _commentRepository.GetAllCommentsAsync();
        }
    }

}
