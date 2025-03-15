namespace FTMS.DTOs
{

    public class CreateChatDto
    {
        public bool IsGroupChat { get; set; }
        public List<string> UserIds { get; set; }
    }

    public class GetChatDto
    {
        public int Id { get; set; }
        public bool IsGroupChat { get; set; }
        public List<string> Users { get; set; }
        public LastMessageDto LastMessage { get; set; }
    }

    public class LastMessageDto
    {
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public string Sender { get; set; }
    }
}
