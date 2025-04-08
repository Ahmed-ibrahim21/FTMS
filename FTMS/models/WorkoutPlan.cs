using System.ComponentModel.DataAnnotations.Schema;

namespace FTMS.models
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<workoutMove> Moves { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public string TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public Trainer Trainer { get; set; }
    }
}
