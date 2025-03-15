using FTMS.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace FTMS.Hubs
{
    public class ReactionHub : Hub
    {
        public async Task JoinPostGroup(int postId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"Post_{postId}");
        }

        public async Task LeavePostGroup(int postId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Post_{postId}");
        }
    }
}