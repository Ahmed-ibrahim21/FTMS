using FTMS.models;
using System.ComponentModel.DataAnnotations;

namespace FTMS.DTOs
{
    public class ReactionDto
    {
        [Required]
        public ReactionType Type { get; set; }

        public int? CommentId { get; set; }
        public int? PostId { get; set; }
    }

}
