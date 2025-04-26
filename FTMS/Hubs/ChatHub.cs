using FTMS.models;
using FTMS.models.models_for_M_M;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;


namespace FTMS.Hubs
{
    public class ChatHub : Hub
    {
        private readonly FTMSContext _context;
        private readonly IUserContextService _userContextService;

        public ChatHub(FTMSContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task SendMessage(int chatId, string messageContent)
        {
            // Get user ID properly
            var senderId = _userContextService.GetUserId();
            // Validate chat membership
            var isValid = await _context.UserChats
                .AnyAsync(uc => uc.ChatId == chatId && uc.UserId == senderId);

            if (!isValid) throw new HubException("Not in chat");

            // Save message
            var message = new Message
            {
                Content = messageContent,
                ChatId = chatId,
                SenderId = senderId,
                SentAt = DateTime.UtcNow
            };

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            // Broadcast
            await Clients.Group(chatId.ToString())
                .SendAsync("ReceiveMessage", senderId, messageContent, chatId);
        }
        public async Task JoinChat(int chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
        }
        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            var userChats = await _context.UserChats
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.ChatId)
                .ToListAsync();

            foreach (var chatId in userChats)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
            }

            await base.OnConnectedAsync();
        }
    }
}
