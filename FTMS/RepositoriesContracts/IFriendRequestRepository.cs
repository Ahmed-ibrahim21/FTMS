using FTMS.models;

namespace FTMS.RepositoriesContracts;

public interface IFriendRequestRepository
{
    Task<FriendRequest> SendRequestAsync(FriendRequest request);
    Task<FriendRequest> GetRequestByIdAsync(int id);
    Task<IEnumerable<FriendRequest>> GetReceivedRequestsAsync(string userId);
    Task<IEnumerable<FriendRequest>> GetSentRequestsAsync(string userId);
    Task UpdateRequestAsync(FriendRequest request);
    Task DeleteRequestAsync(FriendRequest request);
   
}
