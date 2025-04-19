using FTMS.DTOs;

namespace FTMS.ServiceContracts
{
    public interface ICommentService
    {
        Task<GetCommentDto> CreateCommentAsync(CommentDto commentDto);
        Task<GetCommentDto> UpdateCommentAsync(int commentId, CommentDto commentDto);
        Task<bool> DeleteCommentAsync(int commentId);
        Task<GetCommentDto> GetCommentByIdAsync(int commentId);
        Task<List<GetCommentDto>> GetAllCommentsAsync();
        Task<List<GetCommentDto>> GetCommentsByPostIdAsync(int postId);

    }

}
