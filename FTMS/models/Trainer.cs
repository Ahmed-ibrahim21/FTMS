namespace FTMS.models
{
    public class Trainer : User
    {
        public string Speciality { get; set; } = string.Empty;

        public List<Rating>? Ratings { get; set; }

    }
}
