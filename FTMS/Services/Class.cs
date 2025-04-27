// Services/FlaskCalorieService.cs
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FTMS.DTOs;
using Newtonsoft.Json;

namespace CaloriePredictionAPI.Services
{
    public class FlaskCalorieService
    {
        private readonly HttpClient _httpClient;
        private readonly string _flaskApiUrl;

        public FlaskCalorieService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _flaskApiUrl = configuration["FlaskApi:BaseUrl"];
        }

        public async Task<double> PredictCaloriesAsync(PredictionInput input)
        {
            try
            {
                var requestData = new
                {
                    age = input.Age,
                    weight = input.Weight,
                    height = input.Height,
                    gender = input.Gender,
                    activity_level = input.ActivityLevel
                };

                var content = new StringContent(
                    JsonConvert.SerializeObject(requestData),
                    Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.PostAsync($"{_flaskApiUrl}/predict", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Flask API error: {errorContent}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PredictionResult>(responseContent);

                return result.Calories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error calling Flask API", ex);
            }
        }
    }
}