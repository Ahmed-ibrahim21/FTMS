using FTMS.models;

namespace FTMS.DTOs
{
    public class ReactionDto
    {
        public int ReactionId { get; set; }
        public ReactionType Type { get; set; }
        public string UserId { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
    }
}
