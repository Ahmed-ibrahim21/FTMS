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
        public async Task<bool> CreateWorkoutPlanAsync(CreateWorkoutDto workoutPlanDto, string trainerId)
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

        public async Task<bool> UpdateWorkoutPlanAsync(int workoutId, UpdateWorkoutDto updateWorkoutDto, string trainerId)
        {
            var workoutPlan = await _workoutRepository.GetWorkoutPlanByIdAsync(workoutId);
            if (workoutPlan == null || workoutPlan.TrainerId != trainerId)
            {
                return false;
            }
            workoutPlan.Name = updateWorkoutDto.Name;
            workoutPlan.Moves = updateWorkoutDto.Moves.Select(move => new workoutMove
            {
                Sets = move.Sets,
                Reps = move.Reps,
                Name = move.Name,
                Description = move.Description,
                Video = move.Video,
                Image = move.Image
            }).ToList();
            return await _workoutRepository.UpdateWorkoutPlanAsync(workoutPlan);
        }

        public async Task<bool> DeleteWorkoutPlanAsync(int workoutId, string trainerId)
        {
            var workoutPlan = await _workoutRepository.GetWorkoutPlanByIdAsync(workoutId);
            if (workoutPlan == null || workoutPlan.TrainerId != trainerId)
            {
                return false;
            }
            return await _workoutRepository.DeleteWorkoutPlanAsync(workoutId);
        }

        public async Task<bool> DeleteWorkoutMoveAsync(int workoutId, int moveId, string trainerId)
        {
            var workoutPlan = await _workoutRepository.GetWorkoutPlanByIdAsync(workoutId);
            if (workoutPlan == null || workoutPlan.TrainerId != trainerId)
            {
                return false;
            }
            return await _workoutRepository.DeleteWorkoutMoveAsync(workoutId, moveId);
        }

       public async Task<WorkoutResponse> GetWorkoutPlanForUserAsync(int workoutId, string userId)
        {
            var workoutPlan = await _workoutRepository.GetWorkoutPlanByIdAsync(workoutId);
            if (workoutPlan == null)
                throw new Exception("no workout Exists with this Id");
            if(workoutPlan.UserId != userId && workoutPlan.TrainerId != userId)
            {
                throw new Exception("user doesn't have access to this workout");
            }
            else
            {
                WorkoutResponse response = new WorkoutResponse
                {
                    CreatedAt = workoutPlan.CreatedAt,
                    Id = workoutPlan.Id,
                    Name = workoutPlan.Name,
                    TrainerId = workoutPlan.TrainerId,
                    UserId = userId,
                    moves = workoutPlan.Moves.Select(move => new workoutMove
                    {
                        Id = move.Id,
                        Description = move.Description,
                        Image = move.Image,
                         Name = move.Name,
                         Reps = move.Reps,
                         Sets = move.Sets,
                         Video = move.Video,
                    }).ToList(),
                };
                return response;
            }
        }

    }
}