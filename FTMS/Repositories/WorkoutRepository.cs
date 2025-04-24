using FTMS.DTOs;
using FTMS.models;
using FTMS.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace FTMS.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly FTMSContext _context;
        public WorkoutRepository(FTMSContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateWorkoutPlanAsync(WorkoutPlan workoutPlan)
        {
            if(_context.Users.FirstOrDefault(u => u.Id == workoutPlan.UserId) == null)
            {
                return false;
            }
            await _context.WorkoutPlans.AddAsync(workoutPlan);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateWorkoutPlanAsync(WorkoutPlan workoutPlan)
        {
            _context.WorkoutPlans.Update(workoutPlan);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteWorkoutPlanAsync(int workoutPlanId)
        {
            var workoutPlan = await _context.WorkoutPlans.Include(w => w.Moves).FirstOrDefaultAsync(w => w.Id == workoutPlanId);
            if (workoutPlan == null) return false;
            if(workoutPlan.Moves != null)
            {
                foreach (var move in workoutPlan.Moves)
                {
                    _context.workoutMoves.Remove(move);
                }
            }
            _context.WorkoutPlans.Remove(workoutPlan);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<WorkoutPlan> GetWorkoutPlanByIdAsync(int workoutPlanId)
        {
            return await _context.WorkoutPlans.FindAsync(workoutPlanId);
        }
        public async Task<List<WorkoutsResponse>> GetAllWorkoutPlansForUserAsync(string UserId)
        {            
            var workoutPlans = await _context.WorkoutPlans.Where(w => w.UserId == UserId || w.TrainerId == UserId).ToListAsync();
            List<WorkoutsResponse> result = new List<WorkoutsResponse>();
            foreach (var workoutPlan in workoutPlans)
            {
                var trainerName = await _context.Users.FirstOrDefaultAsync(x => x.Id == workoutPlan.TrainerId);
                var UserName = await _context.Users.FirstOrDefaultAsync(x => x.Id == workoutPlan.UserId);
                result.Add(new WorkoutsResponse
                {
                    Id = workoutPlan.Id,
                    Name = workoutPlan.Name,
                    TrainerName = $"{trainerName.FirstName} {trainerName.LastName}",
                    UserName = $"{UserName.FirstName} {UserName.LastName}",
                    CreatedAt = workoutPlan.CreatedAt
                });
            }
            return result;
        }
        public async Task<List<WorkoutPlan>> GetAllWorkoutPlansForTrainerAsync(string TrainerId)
        {
            return await _context.WorkoutPlans.Where(w => w.TrainerId == TrainerId).ToListAsync();
        }

        public async Task<bool> AddWorkoutMoveAsync(workoutMove workoutMove)
        {
            await _context.workoutMoves.AddAsync(workoutMove);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
