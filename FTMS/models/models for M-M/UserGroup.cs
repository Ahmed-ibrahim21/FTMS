namespace FTMS.models.models_for_M_M
{
    public class UserGroup
    {
        //public int Id { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
        public GroupRole Role { get; set; } = GroupRole.Member;
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public User? User { get; set; }
        public Group? Group { get; set; }
    }

    public enum GroupRole
    {
        Owner,
        Admin,
        Member
    }
    public enum RequestStatus
    {
        Pending, 
        Approved,  
        Denied     
    }
}