using FTMS.models;

namespace FTMS.DTOs
{
    public class CreateWorkoutDto
    {
        public string Name { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public IEnumerable<CreateWorkoutMoveDto> Moves { get; set; } = new List<CreateWorkoutMoveDto>();
    }

    public class CreateWorkoutMoveDto
    {
        public int Sets { get; set; }
        public int Reps { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public string? Video { get; set; } = string.Empty;

        public byte[]? Image { get; set; }

    }

    public class WorkoutsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string UserName { get; set; } = string.Empty;

        public string TrainerName { get; set; } = string.Empty;
    }

    public class WorkoutResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }

        public string TrainerId { get;set; } = string.Empty;

        public IEnumerable<workoutMove> moves { get; set; }
    }

    public class UpdateWorkoutDto
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<CreateWorkoutMoveDto> Moves { get; set; } = new List<CreateWorkoutMoveDto>();
    } 
}