using FTMS.DTOs;
using FTMS.models;
using FTMS.models.models_for_M_M;
using FTMS.ServiceContracts;
using FTMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FTMS.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly FTMSContext _context;
        private readonly IUserContextService _userContextService;
        private readonly IChatService _chatService;

        public ChatController(FTMSContext context, IUserContextService userContextService,IChatService chatService)
        {
            _context = context;
            _chatService = chatService;
            _userContextService = userContextService;
        }

        [HttpGet("{chatId}/messages")]
        public async Task<IActionResult> GetMessages(int chatId)
        {
            var messages = await _context.Messages
                .Where(m => m.ChatId == chatId)
                .OrderBy(m => m.SentAt)
                .Include(m => m.Sender)
                .Select(m => new MessageDto
                {
                    Content = m.Content,
                    Sender = m.Sender.UserName,
                    Timestamp = m.SentAt
                })
                .AsNoTracking()
                .ToListAsync();

            return Ok(messages);
        }

        [HttpPost("chats")]
        public async Task<IActionResult> CreateChat([FromBody] CreateChatDto request)
        {
            // Validate input
            if (request.UserIds.Count < 2)
                return BadRequest("chat requires exactly 2 users");

            // Check for existing private chat
            if (!request.IsGroupChat)
            {
                var existingChatId = await FindExistingPrivateChat(request.UserIds[0], request.UserIds[1]);
                if (existingChatId.HasValue && existingChatId != 0)
                    return Ok(new { ChatId = existingChatId.Value });
            }

            // Create new chat
            var chat = new Chat
            {
                IsGroupChat = request.IsGroupChat,
            };

            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();

            // Add users to chat
            var userChats = request.UserIds.Select(userId => new UserChats
            {
                UserId = userId,
                ChatId = chat.id
            });

            _context.UserChats.AddRange(userChats);
            await _context.SaveChangesAsync();

            return Ok(new { ChatId = chat.id });
        }

        private async Task<int?> FindExistingPrivateChat(string userId1, string userId2)
        {
            return await _context.UserChats
                .Where(uc => uc.UserId == userId1)
                .Select(uc => uc.ChatId)
                .Intersect(
                    _context.UserChats
                        .Where(uc => uc.UserId == userId2)
                        .Select(uc => uc.ChatId)
                )
                .Join(
                    _context.Chats.Where(c => !c.IsGroupChat),
                    chatId => chatId,
                    chat => chat.id,
                    (chatId, chat) => chatId
                )
                .FirstOrDefaultAsync();
        }


        [HttpGet("chats")]
        [Authorize]
        public async Task<IActionResult> GetChats()
        {
            var userId = _userContextService.GetUserId();

            var chats = await _context.Chats
                .Where(c => c.userChats.Any(uc => uc.UserId == userId))
                .Select(c => new GetChatDto
                {
                    Id = c.id,
                    IsGroupChat = c.IsGroupChat,
                    Users = c.userChats
                        .Select(uc => uc.User.UserName)
                        .ToList(),
                    LastMessage = c.messages
                        .OrderByDescending(m => m.SentAt)
                        .Select(m => new LastMessageDto
                        {
                            Content = m.Content,
                            SentAt = m.SentAt,
                            Sender = m.Sender.UserName
                        })
                        .FirstOrDefault()
                })
                .AsNoTracking()
                .ToListAsync();

            return Ok(chats);
        }


    }
}
