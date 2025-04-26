using FTMS.models;
using FTMS.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace FTMS.Repositories
{
    public class DietplanRepository : IDietPlanRepository
    {
        private readonly FTMSContext _context;
        public DietplanRepository(FTMSContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateDietPlanAsync(DietPlan dietPlan)
        {
            await _context.DietPlans.AddAsync(dietPlan);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddDietMealAsync(DietMeal dietMeal)
        {
            await _context.dietMeals.AddAsync(dietMeal);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<DietPlan>> GetAllDietPlansForUserAsync(string userId)
        {
            return await _context.DietPlans
                .Include(dp => dp.meals)
                .ThenInclude(dm => dm.ingredients)
                .Where(dp => dp.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> UpdateDietPlanAsync(int dietPlanId, DietPlan dietPlan)
        {
            var existingDietPlan = await _context.DietPlans.FindAsync(dietPlanId);
            if (existingDietPlan == null)
            {
                return false;
            }
            existingDietPlan.Name = dietPlan.Name;
            existingDietPlan.UserId = dietPlan.UserId;
            existingDietPlan.TrainerId = dietPlan.TrainerId;
            existingDietPlan.meals = dietPlan.meals;
            _context.DietPlans.Update(existingDietPlan);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<DietPlan> GetDietPlanByIdAsync(int dietPlanId)
        {
            return await _context.DietPlans
                .Include(dp => dp.meals)
                .ThenInclude(dm => dm.ingredients)
                .FirstOrDefaultAsync(dp => dp.Id == dietPlanId);
        }

        public async Task<bool> DeleteDietPlanAsync(DietPlan dietPlan, string trainerId)
        {
            if (dietPlan == null || dietPlan.TrainerId != trainerId)
            {
                return false;
            }
            _context.DietPlans.Remove(dietPlan);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteDietMealAsync(DietMeal dietMeal, string trainerId)
        {
            if (dietMeal == null)
            {
                return false;
            }
            _context.dietMeals.Remove(dietMeal);
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
