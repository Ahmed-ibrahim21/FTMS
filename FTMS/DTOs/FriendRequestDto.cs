using FTMS.models;

namespace FTMS.DTOs;

public class FriendRequestDto
{
    public int Id { get; set; }
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public Status RequestStatus { get; set; }
}

public class CreateFriendRequestDto
{
    public string ReceiverId { get; set; }
}

public class UpdateFriendRequestDto
{
    public int RequestId { get; set; }
}