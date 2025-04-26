using FTMS.models;

namespace FTMS.RepositoriesContracts
{
    public interface IDietPlanRepository
    {
        Task<bool> CreateDietPlanAsync(DietPlan dietPlan);

        Task<bool> AddDietMealAsync(DietMeal dietMeal);

        Task<IEnumerable<DietPlan>> GetAllDietPlansForUserAsync(string userId);

        Task<bool> UpdateDietPlanAsync(int dietPlanId, DietPlan dietPlan);

        Task<DietPlan> GetDietPlanByIdAsync(int dietPlanId);

        Task<bool> DeleteDietPlanAsync(DietPlan dietPlan, string trainerId);

        Task<bool> DeleteDietMealAsync(DietMeal dietMeal, string trainerId);

    }
}
