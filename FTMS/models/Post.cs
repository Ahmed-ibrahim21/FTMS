using System.ComponentModel.DataAnnotations;

namespace FTMS.models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [MaxLength(1000)]
        public string Text { get; set; }

        public byte[] Image { get; set; }

        public string VideoUrl { get; set; }

        public DateTime TimeStamp { get; set; }

        List<Reaction> Reactions { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public int? GroupId { get; set; }

        public Group Group { get; set; }   
    }
}
