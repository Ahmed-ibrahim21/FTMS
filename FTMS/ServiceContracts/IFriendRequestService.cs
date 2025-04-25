using FTMS.DTOs;
using FTMS.models;

namespace FTMS.ServiceContracts;

public interface IFriendRequestService
{
    Task<FriendRequestDto> SendRequestAsync(string senderId, CreateFriendRequestDto requestDto);
    Task AcceptRequestAsync(int requestId);
    Task RejectRequestAsync(int requestId);
    Task CancelRequestAsync(int requestId);
    Task<IEnumerable<FriendRequestDto>> GetReceivedRequestsAsync(string userId);
    Task<IEnumerable<User>> GetAllFriendsAsync(string userId);

    Task<IEnumerable<FriendRequestDto>> GetSentRequestsAsync(string userId);
}
