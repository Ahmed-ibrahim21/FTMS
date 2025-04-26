using FTMS.DTOs;
using FTMS.models;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;

namespace FTMS.Services
{
    public class DietPlanService : IDietplanService
    {
        private readonly IDietPlanRepository _dietPlanRepository;
        public DietPlanService(IDietPlanRepository dietPlanRepository)
        {
            _dietPlanRepository = dietPlanRepository;
        }
        public async Task<bool> CreateDietPlanAsync(CreateDietplanDto dietplanDto, string trainerId)
        {
            var dietPlan = new DietPlan
            {
                Name = dietplanDto.Name,
                UserId = dietplanDto.UserId,
                TrainerId = trainerId,
                meals = dietplanDto.Meals.Select(meal => new DietMeal
                {
                    Name = meal.Name,
                    Description = meal.Description,
                    Video = meal.Video,
                    Image = meal.Image,
                    ingredients = meal.Ingredients.Select(ingredient => new Ingredients
                    {
                        Name = ingredient.Name,
                        weight = ingredient.Weight
                    }).ToList()
                }).ToList()
            };

            return await _dietPlanRepository.CreateDietPlanAsync(dietPlan);
        }

        public async Task<bool> AddDietMealAsync(int dietPlanId, CreateDietMealDto dietMealDto)
        {
            var dietMeal = new DietMeal
            {
                dietPlanId = dietPlanId,
                Name = dietMealDto.Name,
                Description = dietMealDto.Description,
                Video = dietMealDto.Video,
                Image = dietMealDto.Image,
                ingredients = dietMealDto.Ingredients.Select(ingredient => new Ingredients
                {
                    Name = ingredient.Name,
                    weight = ingredient.Weight
                }).ToList()
            };
            return await _dietPlanRepository.AddDietMealAsync(dietMeal);
        }

        public async Task<IEnumerable<DietPlanResponse>> GetAllDietPlansForUserAsync(string userId)
        {
            var dietPlans = await _dietPlanRepository.GetAllDietPlansForUserAsync(userId);
            return dietPlans.Select(dietPlan => new DietPlanResponse
            {
                Id = dietPlan.Id,
                Name = dietPlan.Name,
                UserId = dietPlan.UserId,
                TrainerId = dietPlan.TrainerId,
                Meals = dietPlan.meals.Select(meal => new DietMealResponse
                {
                    Id = meal.id,
                    Name = meal.Name,
                    Description = meal.Description,
                    Video = meal.Video,
                    Image = meal.Image,
                    Ingredients = meal.ingredients.Select(ingredient => new IngredientResponse
                    {
                        Name = ingredient.Name,
                        Weight = ingredient.weight
                    }).ToList()
                }).ToList()
            });
        }

        public async Task<bool> UpdateDietPlanAsync(int dietPlanId, UpdateDietPlanDto updateDietPlanDto, string trainerId)
        {
            var dietPlan = await _dietPlanRepository.GetDietPlanByIdAsync(dietPlanId);
            if (dietPlan == null || dietPlan.TrainerId != trainerId)
            {
                return false;
            }
            dietPlan.Name = updateDietPlanDto.Name;
            dietPlan.meals = updateDietPlanDto.Meals.Select(meal => new DietMeal
            {
                Name = meal.Name,
                Description = meal.Description,
                Video = meal.Video,
                Image = meal.Image,
                ingredients = meal.Ingredients.Select(ingredient => new Ingredients
                {
                    Name = ingredient.Name,
                    weight = ingredient.Weight
                }).ToList()
            }).ToList();
            return await _dietPlanRepository.UpdateDietPlanAsync(dietPlanId, dietPlan);
        }

        public async Task<DietPlanResponse> GetDietPlanByIdAsync(int dietPlanId)
        {
            var dietPlan = await _dietPlanRepository.GetDietPlanByIdAsync(dietPlanId);
            if (dietPlan == null)
            {
                return null;
            }
            return new DietPlanResponse
            {
                Id = dietPlan.Id,
                Name = dietPlan.Name,
                UserId = dietPlan.UserId,
                TrainerId = dietPlan.TrainerId,
                Meals = dietPlan.meals.Select(meal => new DietMealResponse
                {
                    Id = meal.id,
                    Name = meal.Name,
                    Description = meal.Description,
                    Video = meal.Video,
                    Image = meal.Image,
                    Ingredients = meal.ingredients.Select(ingredient => new IngredientResponse
                    {
                        Name = ingredient.Name,
                        Weight = ingredient.weight
                    }).ToList()
                }).ToList()
            };
        }

        public async Task<bool> DeleteDietPlanAsync(int dietPlanId, string trainerId)
        {
            var dietPlan = await _dietPlanRepository.GetDietPlanByIdAsync(dietPlanId);
            if (dietPlan == null || dietPlan.TrainerId != trainerId)
            {
                return false;
            }
            return await _dietPlanRepository.DeleteDietPlanAsync(dietPlan, trainerId);
        }

        public Task<bool> DeleteDietMealAsync(int dietPlanId, int mealId, string trainerId)
        {
            throw new NotImplementedException();
        }
    }
}