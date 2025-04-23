using System.ComponentModel.DataAnnotations.Schema;

namespace FTMS.models
{
    public class workoutMove
    {
        public int Id { get; set; }

        public int WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public WorkoutPlan WorkoutPlan { get; set; }

        public int Sets { get; set; }
        public int Reps { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public string? Video { get; set; } = string.Empty;

        public byte[]? Image { get; set; }
    }
}
