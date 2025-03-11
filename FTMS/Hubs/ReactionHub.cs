using FTMS.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace FTMS.Hubs
{
    public class ReactionHub : Hub
    {
        public async Task SendReaction(GetReactionDto reaction)
        {
            await Clients.All.SendAsync("ReceiveReaction", reaction);
        }

        public async Task RemoveReaction(int reactionId)
        {
            await Clients.All.SendAsync("RemoveReaction", reactionId);
        }
    }

}
