using FTMS.DTOs;

namespace FTMS.ServiceContracts
{
    public interface IDietplanService
    {
        Task<bool> CreateDietPlanAsync(CreateDietplanDto createDietplanDto, string trainerId);

        Task<IEnumerable<DietPlanResponse>> GetAllDietPlansForUserAsync(string userId);

        Task<bool> AddDietMealAsync(int dietPlanId, CreateDietMealDto createDietMealDto);

        Task<bool> UpdateDietPlanAsync(int dietPlanId, UpdateDietPlanDto updateDietPlanDto, string trainerId);

        Task<DietPlanResponse> GetDietPlanByIdAsync(int dietPlanId,string userId);

        Task<bool> DeleteDietPlanAsync(int dietPlanId, string trainerId);

        Task<bool> DeleteDietMealAsync(int dietPlanId, int mealId, string trainerId);
    }
}
