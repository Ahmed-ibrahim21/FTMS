namespace FTMS.models
{
    public class Trainer : User
    {
        public string Speciality { get; set; }

        public List<Rating> Ratings { get; set; }

    }
}
