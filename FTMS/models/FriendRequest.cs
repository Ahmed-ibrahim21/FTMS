using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTMS.models
{
    public class FriendRequest
    {
        [Key]
        public int Id { get; set; }

        public string SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User sender { get; set; }

        public string ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }

        public Status RequestStatus { get; set; }
    }
}
