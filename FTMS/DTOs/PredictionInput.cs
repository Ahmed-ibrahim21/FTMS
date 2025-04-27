namespace FTMS.DTOs
{
    public class PredictionInput
    {
        public int Age { get; set; }
        public double Weight { get; set; } // in kg
        public double Height { get; set; } // in meters
        public string Gender { get; set; } // "M" or "F"
        public double ActivityLevel { get; set; } // 1.2 to 1.9
    }
}
