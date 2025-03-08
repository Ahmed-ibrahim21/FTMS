using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTMS.models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public string SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        public string RecieverId { get; set; }
        [ForeignKey("RecieverId")]
        public User Reciever { get; set; }
        public int ChatId { get; set; }
        
        [ForeignKey("ChatId")]
        public Chat Chat { get; set; }
    }
}
