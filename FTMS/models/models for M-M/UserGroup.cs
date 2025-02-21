namespace FTMS.models.models_for_M_M
{
    public class UserGroup
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }

}
