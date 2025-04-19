using System.ComponentModel.DataAnnotations;

namespace FTMS.DTOs
{
    public class CommentDto
    {
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }
        [Required]
        public int PostId { get; set; }
    }

}
