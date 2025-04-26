using FTMS.DTOs;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietController : ControllerBase
    {
        private readonly IUserContextService _userContextService;
        private readonly IDietplanService _dietService;
        public DietController(IUserContextService userContextService, IDietplanService dietService)
        {
            _userContextService = userContextService;
            _dietService = dietService;
        }

        [Authorize(Roles = "Admin,Trainer")]
        [HttpPost]
        public async Task<IActionResult> CreateDietPlan([FromBody] CreateDietplanDto createDietplanDto)
        {
            if (createDietplanDto == null)
                return BadRequest("diet plan data is required.");
            var trainerId = _userContextService.GetUserId();
            var dietPlan = await _dietService.CreateDietPlanAsync(createDietplanDto, trainerId);

            return Ok(new { message = "Diet plan created successfully." });
        }


        [HttpPost("{dietPlanId}/meal")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> AddDietMeal(int dietPlanId, [FromBody] CreateDietMealDto createDietMealDto)
        {
            if (createDietMealDto == null)
                return BadRequest("diet meal data is required.");
            var result = await _dietService.AddDietMealAsync(dietPlanId, createDietMealDto);
            if (result)
                return Ok(new { message = "Diet meal added successfully." });
            else
                return BadRequest("Failed to add diet meal.");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMyDietPlans()
        {
            var userId = _userContextService.GetUserId();
            var dietPlans = await _dietService.GetAllDietPlansForUserAsync(userId);
            return Ok(dietPlans);
        }

        [HttpPut("{dietPlanId}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> UpdateDietPlan(int dietPlanId, [FromBody] UpdateDietPlanDto updateDietPlanDto)
        {
            if (updateDietPlanDto == null)
                return BadRequest("Diet plan data is required.");
            var trainerId = _userContextService.GetUserId();
            var result = await _dietService.UpdateDietPlanAsync(dietPlanId, updateDietPlanDto, trainerId);
            if (result)
                return Ok(new { message = "Diet plan updated successfully." });
            else
                return BadRequest("Failed to update diet plan.");
        }

        [HttpDelete("{dietPlanId}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> DeleteDietPlan(int dietPlanId)
        {
            var trainerId = _userContextService.GetUserId();
            var result = await _dietService.DeleteDietPlanAsync(dietPlanId, trainerId);
            if (result)
                return Ok(new { message = "Diet plan deleted successfully." });
            else
                return BadRequest("Failed to delete diet plan.");
        }

    }

}

