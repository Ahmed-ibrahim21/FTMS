using FTMS.DTOs;
using FTMS.Hubs;
using FTMS.models;
using FTMS.Repositories;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.SignalR;

namespace FTMS.Services;

public class FriendRequestService: IFriendRequestService
{
    private readonly IFriendRequestRepository _repository;
    private readonly IHubContext<FriendRequestHub> _hubContext; 

    public FriendRequestService(IFriendRequestRepository repository, IHubContext<FriendRequestHub> hubContext)
    {
        _repository = repository;
        _hubContext = hubContext;
    }

    public async Task<FriendRequestDto> SendRequestAsync(string senderId, CreateFriendRequestDto requestDto)
    {

        var friendRequest = new FriendRequest
        {
            SenderId = senderId,
            ReceiverId = requestDto.ReceiverId,
            RequestStatus = Status.Pending
        };

        var createdRequest = await _repository.SendRequestAsync(friendRequest);

        string notificationMessage = $"You have received a friend request from user {senderId}";
        await _hubContext.Clients.User(requestDto.ReceiverId).SendAsync("ReceiveFriendRequest", notificationMessage);

        return new FriendRequestDto
        {
            Id = createdRequest.Id,
            SenderId = createdRequest.SenderId,
            ReceiverId = createdRequest.ReceiverId,
            RequestStatus = createdRequest.RequestStatus,
            SentDate = createdRequest.SentDate

        };
    }

    public async Task AcceptRequestAsync(int requestId)
    {
        var request = await _repository.GetRequestByIdAsync(requestId);
        if (request == null) throw new Exception("Friend request not found");

        request.RequestStatus = Status.Accepted;
        await _repository.UpdateRequestAsync(request);

        string notificationMessage = $"User {request.ReceiverId} accepted your friend request.";
        await _hubContext.Clients.User(request.SenderId).SendAsync("ReceiveFriendRequestUpdate", notificationMessage);
    }

    public async Task RejectRequestAsync(int requestId)
    {
        var request = await _repository.GetRequestByIdAsync(requestId);
        if (request == null) throw new Exception("Friend request not found");

        request.RequestStatus = Status.Rejected;
        await _repository.UpdateRequestAsync(request);

        string notificationMessage = $"User {request.ReceiverId} rejected your friend request.";
        await _hubContext.Clients.User(request.SenderId).SendAsync("ReceiveFriendRequestUpdate", notificationMessage);
    }

    public async Task CancelRequestAsync(int requestId)
    {
        var request = await _repository.GetRequestByIdAsync(requestId);
        if (request == null) throw new Exception("Friend request not found");

        await _repository.DeleteRequestAsync(request);
    }

    public async Task<IEnumerable<FriendRequestDto>> GetReceivedRequestsAsync(string userId)
    {
        var requests = await _repository.GetReceivedRequestsAsync(userId);
        return requests.Select(r => new FriendRequestDto
        {
            Id = r.Id,
            SenderId = r.SenderId,
            ReceiverId = r.ReceiverId,
            RequestStatus = r.RequestStatus,
            SentDate = r.SentDate
        });
    }

    public async Task<IEnumerable<FriendRequestDto>> GetSentRequestsAsync(string userId)
    {
        var requests = await _repository.GetSentRequestsAsync(userId);
        return requests.Select(r => new FriendRequestDto
        {
            Id = r.Id,
            SenderId = r.SenderId,
            ReceiverId = r.ReceiverId,
            RequestStatus = r.RequestStatus,
            SentDate = r.SentDate
        });
    }
    public async Task<IEnumerable<User>> GetAllFriendsAsync(string userId)
    {
        var friends = await _repository.GetAllFriendsAsync(userId);
        return friends;
    }

}
