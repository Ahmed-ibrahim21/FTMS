using FTMS.models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace FTMS.Hubs
{
    public class ChatHub : Hub
    {
        private readonly FTMSContext _context;

        public ChatHub(FTMSContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string senderId, string receiverId, string message)
        {
            // Find an existing chat between these users
            var chat = _context.Chats
                .Include(c => c.messages)
                .FirstOrDefault(c => c.messages.Any(m =>
                    (m.SenderId == senderId && m.RecieverId == receiverId) ||
                    (m.SenderId == receiverId && m.RecieverId == senderId)));

            // If no chat exists, create a new one
            if (chat == null)
            {
                chat = new Chat();
                _context.Chats.Add(chat);
                await _context.SaveChangesAsync();
            }

            // Save the message
            var newMessage = new Message
            {
                ChatId = chat.id,
                SenderId = senderId,
                RecieverId = receiverId,
                Content = message,
                SentAt = DateTime.UtcNow
            };

            _context.Messages.Add(newMessage);
            await _context.SaveChangesAsync();

            // Notify the receiver in real-time
            await Clients.User(receiverId).SendAsync("ReceiveMessage", senderId, message);
        }

        public async Task<List<Message>> GetChatHistory(string senderId, string receiverId)
        {
            var chat = _context.Chats
                .Include(c => c.messages)
                .FirstOrDefault(c => c.messages.Any(m =>
                    (m.SenderId == senderId && m.RecieverId == receiverId) ||
                    (m.SenderId == receiverId && m.RecieverId == senderId)));

            if (chat == null)
                return new List<Message>();

            return chat.messages.OrderBy(m => m.SentAt).ToList();
        }
    }
}
