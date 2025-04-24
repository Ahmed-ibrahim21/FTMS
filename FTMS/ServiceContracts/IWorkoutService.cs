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

    }
}
