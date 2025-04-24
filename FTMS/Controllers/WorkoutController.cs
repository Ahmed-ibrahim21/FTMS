using FTMS.DTOs;
using FTMS.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FTMS.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IUserContextService _userContextService;
        private readonly IWorkoutService _workoutService;
        public WorkoutController(IUserContextService userContextService, IWorkoutService workoutService)
        {
            _userContextService = userContextService;
            _workoutService = workoutService;
        }

        [Authorize(Roles = "Admin,Trainer")]
        [HttpPost]
        public async Task<IActionResult> CreateWorkoutPlan([FromBody] CreateWorkoutDto createWorkoutDto)
        {
            if (createWorkoutDto == null)
                return BadRequest("Workout plan data is required.");
            var trainerId = _userContextService.GetUserId();
            var workoutPlan = await _workoutService.CreateWorkoutPlanAsync(createWorkoutDto, trainerId);

            return Ok(new { message = "Workout plan created successfully." });
        }

        [HttpPost("{workoutId}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> AddWorkoutMove(int workoutId, [FromBody] CreateWorkoutMoveDto createWorkoutMoveDto)
        {
            if (createWorkoutMoveDto == null)
                return BadRequest("Workout move data is required.");
            var result = await _workoutService.AddWorkoutMoveAsync(workoutId, createWorkoutMoveDto);
            if (result)
                return Ok(new { message = "Workout move added successfully." });
            else
                return BadRequest("Failed to add workout move.");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMyWorkOutPlans()
        {
            var userId = _userContextService.GetUserId();
            var workoutPlans = await _workoutService.GetAllWorkoutPlansForUserAsync(userId);
            return Ok(workoutPlans);
        }

        [HttpPut("{workoutId}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> UpdateWorkoutPlan(int workoutId, [FromBody] UpdateWorkoutDto updateWorkoutDto)
        {
            if (updateWorkoutDto == null)
                return BadRequest("Workout plan data is required.");
            var trainerId = _userContextService.GetUserId();
            var result = await _workoutService.UpdateWorkoutPlanAsync(workoutId,updateWorkoutDto,trainerId);
            if (result)
                return Ok(new { message = "Workout plan updated successfully." });
            else
                return BadRequest("Failed to update workout plan.");
        }

        [HttpDelete("{workoutId}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> DeleteWorkoutPlan(int workoutId)
        {
            var trainerId = _userContextService.GetUserId();
            var result = await _workoutService.DeleteWorkoutPlanAsync(workoutId, trainerId);
            if (result)
                return Ok(new { message = "Workout plan deleted successfully." });
            else
                return BadRequest("Failed to delete workout plan.");
        }

    }
}
