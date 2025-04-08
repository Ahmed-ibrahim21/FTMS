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
            var workoutPlan = await _context.WorkoutPlans.FindAsync(workoutPlanId);
            if (workoutPlan == null) return false;
            _context.WorkoutPlans.Remove(workoutPlan);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<WorkoutPlan> GetWorkoutPlanByIdAsync(int workoutPlanId)
        {
            return await _context.WorkoutPlans.FindAsync(workoutPlanId);
        }
        public async Task<List<WorkoutPlan>> GetAllWorkoutPlansForUserAsync(string UserId)
        {
            return await _context.WorkoutPlans.Where(w => w.UserId == UserId).ToListAsync();
        }
        public async Task<List<WorkoutPlan>> GetAllWorkoutPlansForTrainerAsync(string TrainerId)
        {
            return await _context.WorkoutPlans.Where(w => w.TrainerId == TrainerId).ToListAsync();
        }
    }
}
