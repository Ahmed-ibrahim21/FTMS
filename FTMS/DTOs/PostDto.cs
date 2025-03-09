namespace FTMS.DTOs
{
    public class PostDto
    {
        public string Text { get; set; }
        public IFormFile Image { get; set; } 
        public IFormFile Video { get; set; } 
        public int? GroupId { get; set; }
    }

}
