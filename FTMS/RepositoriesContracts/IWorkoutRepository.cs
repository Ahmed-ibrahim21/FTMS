using FTMS.models;

namespace FTMS.RepositoriesContracts
{
    public interface IWorkoutRepository
    {
        public Task<bool> CreateWorkoutPlanAsync(WorkoutPlan workoutPlan);

        public Task<bool> UpdateWorkoutPlanAsync(WorkoutPlan workoutPlan);

        public Task<bool> DeleteWorkoutPlanAsync(int workoutPlanId);

        public Task<WorkoutPlan> GetWorkoutPlanByIdAsync(int workoutPlanId);

        public Task<List<WorkoutPlan>> GetAllWorkoutPlansForUserAsync(string UserId);

        public Task<List<WorkoutPlan>> GetAllWorkoutPlansForTrainerAsync(string TrainerId);
    }
}
