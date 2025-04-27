// Controllers/CalorieController.cs
using Microsoft.AspNetCore.Mvc;
using CaloriePredictionAPI.Services;
using System.Threading.Tasks;
using FTMS.DTOs;

namespace CaloriePredictionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalorieController : ControllerBase
    {
        private readonly FlaskCalorieService _flaskService;

        public CalorieController(FlaskCalorieService flaskService)
        {
            _flaskService = flaskService;
        }

        [HttpPost("predict")]
        public async Task<ActionResult<PredictionResult>> Predict([FromBody] PredictionInput input)
        {
            try
            {
                if (input.Gender != "M" && input.Gender != "F")
                    return BadRequest("Gender must be 'M' or 'F'");

                if (input.ActivityLevel < 1.2 || input.ActivityLevel > 1.9)
                    return BadRequest("Activity level must be between 1.2 and 1.9");

                var calories = await _flaskService.PredictCaloriesAsync(input);
                return Ok(new PredictionResult { Calories = calories });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}