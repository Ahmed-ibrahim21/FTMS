using FTMS.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly FTMSContext _context;

        public ChatController(FTMSContext context)
        {
            _context = context;
        }

        [HttpGet("history/{user1}/{user2}")]
        public async Task<IActionResult> GetChatHistory(string user1,string user2)
        {
            var chat = await _context.Chats
                .Include(c => c.messages)
                .FirstOrDefaultAsync(c => c.messages.Any(m =>
                    (m.SenderId == user1 && m.RecieverId == user2) ||
                    (m.SenderId == user2 && m.RecieverId == user1)));

            if (chat == null)
                return Ok(new List<Message>());

            return Ok(chat.messages.OrderBy(m => m.SentAt).ToList());
        }
    }
}
