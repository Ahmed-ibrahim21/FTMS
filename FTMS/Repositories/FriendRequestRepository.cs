using FTMS.models;
using FTMS.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace FTMS.Repositories;

public class FriendRequestRepository: IFriendRequestRepository
{
    private readonly FTMSContext _context;

    public FriendRequestRepository(FTMSContext context)
    {
        _context = context;
    }

    public async Task<FriendRequest> SendRequestAsync(FriendRequest request)
    {
        await _context.FriendRequests.AddAsync(request);
        await _context.SaveChangesAsync();
        return request;
    }

    public async Task<FriendRequest> GetRequestByIdAsync(int id)
    {
        return await _context.FriendRequests.FindAsync(id);
    }

    public async Task<IEnumerable<FriendRequest>> GetReceivedRequestsAsync(string userId)
    {
        return await _context.FriendRequests
            .Where(fr => fr.ReceiverId == userId && fr.RequestStatus == Status.Pending)
            .ToListAsync();
    }

    public async Task<IEnumerable<FriendRequest>> GetSentRequestsAsync(string userId)
    {
        return await _context.FriendRequests
            .Where(fr => fr.SenderId == userId && fr.RequestStatus == Status.Pending)
            .ToListAsync();
    }

    public async Task UpdateRequestAsync(FriendRequest request)
    {
        _context.FriendRequests.Update(request);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRequestAsync(FriendRequest request)
    {
        _context.FriendRequests.Remove(request);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<User>> GetAllFriendsAsync(string userId)
    {
        return await _context.FriendRequests
            .Where(fr => fr.RequestStatus == Status.Accepted &&
                (fr.SenderId == userId || fr.ReceiverId == userId))
            .Select(fr => fr.SenderId == userId ? fr.Receiver : fr.sender)
            .Distinct()
            .ToListAsync();
    }

}

