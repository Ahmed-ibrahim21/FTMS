using System.ComponentModel.DataAnnotations;

namespace FTMS.DTOs
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
    }

}
