using System.ComponentModel.DataAnnotations;

namespace FTMS.models
{
    public class Reaction
    {
        [Key]
        public int ReactionId { get; set; }

        [Required]
        public ReactionType Type { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int? CommentId { get; set; }

        public Comment Comment { get; set; }

        public int? PostId { get; set; }

        public Post Post { get; set; }
    }
}
