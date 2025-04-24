using FTMS.DTOs;
using FTMS.models;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;

namespace FTMS.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }
        public async Task<bool> CreateWorkoutPlanAsync(CreateWorkoutDto workoutPlanDto,string trainerId)
        {
            var workoutPlan = new WorkoutPlan
            {
                Name = workoutPlanDto.Name,
                UserId = workoutPlanDto.UserId,
                TrainerId = trainerId,
                Moves = workoutPlanDto.Moves.Select(move => new workoutMove
                {
                    Sets = move.Sets,
                    Reps = move.Reps,
                    Name = move.Name,
                    Description = move.Description,
                    Video = move.Video,
                    Image = move.Image
                }).ToList()
            };
            return await _workoutRepository.CreateWorkoutPlanAsync(workoutPlan);
        }

        public async Task<bool> AddWorkoutMoveAsync(int workoutId, CreateWorkoutMoveDto workoutMoveDto)
        {
            var workoutMove = new workoutMove
            {
                WorkoutId = workoutId,
                Sets = workoutMoveDto.Sets,
                Reps = workoutMoveDto.Reps,
                Name = workoutMoveDto.Name,
                Description = workoutMoveDto.Description,
                Video = workoutMoveDto.Video,
                Image = workoutMoveDto.Image,
            };
            return await _workoutRepository.AddWorkoutMoveAsync(workoutMove);
        }

        public async Task<IEnumerable<WorkoutsResponse>> GetAllWorkoutPlansForUserAsync(string userId)
        {
            var workoutPlans = await _workoutRepository.GetAllWorkoutPlansForUserAsync(userId);
            return workoutPlans;
        }
    }
}
