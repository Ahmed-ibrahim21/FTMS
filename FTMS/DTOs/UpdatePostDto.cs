namespace FTMS.DTOs
{
    public class UpdatePostDto
    {
        public string Text { get; set; }
        public IFormFile? Image { get; set; }
        public IFormFile? Video { get; set; }
    }
}
