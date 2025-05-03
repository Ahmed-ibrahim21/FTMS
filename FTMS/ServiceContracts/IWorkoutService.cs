using FTMS.DTOs;
using FTMS.models;

namespace FTMS.ServiceContracts
{
    public interface IWorkoutService
    {
        Task<bool> CreateWorkoutPlanAsync(CreateWorkoutDto workoutPlanDto, string trainerId);

        Task<bool> AddWorkoutMoveAsync(int workoutId, CreateWorkoutMoveDto workoutMoveDto);

        Task<IEnumerable<WorkoutsResponse>> GetAllWorkoutPlansForUserAsync(string userId);

        Task<bool> UpdateWorkoutPlanAsync(int workoutId, UpdateWorkoutDto updateWorkoutDto,string trainerId);

        Task<bool> DeleteWorkoutPlanAsync(int workoutId, string trainerId);

        Task<bool> DeleteWorkoutMoveAsync(int workoutId, int moveId,string trainerId);

        Task<WorkoutResponse> GetWorkoutPlanForUserAsync(int workoutId, string userId);

    }
}
