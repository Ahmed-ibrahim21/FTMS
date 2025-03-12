namespace FTMS.DTOs
{
    public class GetPostDto
    {
        public int PostId { get; set; }
        public string Text { get; set; }
        public byte[] Image { get; set; }
        public byte[] Video { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserId { get; set; }
        public int? GroupId { get; set; }
    }
}
