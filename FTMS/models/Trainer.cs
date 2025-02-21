namespace FTMS.models
{
    public class Trainer : Person
    {
        public string Speciality { get; set; }

        public List<Rating> Ratings { get; set; }

    }
}
