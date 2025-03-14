using FTMS.DTOs;

namespace FTMS.ServiceContracts;

public interface IFriendRequestService
{
    Task<FriendRequestDto> SendRequestAsync(string senderId, CreateFriendRequestDto requestDto);
    Task AcceptRequestAsync(int requestId);
    Task RejectRequestAsync(int requestId);
    Task CancelRequestAsync(int requestId);
    Task<IEnumerable<FriendRequestDto>> GetReceivedRequestsAsync(string userId);
    Task<IEnumerable<FriendRequestDto>> GetSentRequestsAsync(string userId);
}
