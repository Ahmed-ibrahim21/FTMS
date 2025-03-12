using Microsoft.AspNetCore.SignalR;

namespace FTMS.Hubs;

public class FriendRequestHub : Hub
{
     public async Task SendFriendRequestNotification(string receiverId, string message)
     {
         await Clients.User(receiverId).SendAsync("ReceiveFriendRequest", message);
     }
}
