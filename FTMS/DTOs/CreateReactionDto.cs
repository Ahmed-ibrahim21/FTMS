using FTMS.models;

namespace FTMS.DTOs
{
    public class CreateReactionDto
    {
        public ReactionType Type { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
    }
}
