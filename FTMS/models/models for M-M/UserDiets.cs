namespace FTMS.models.models_for_M_M
{
    public class UserDiets
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int DietId { get; set; }

        public DietPlan DietPlan { get; set; }
    }
}
