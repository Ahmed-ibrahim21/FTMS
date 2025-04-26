namespace FTMS.DTOs
{
    public class CreateDietplanDto
    {
        public string Name { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public IEnumerable<CreateDietMealDto> Meals { get; set; } = new List<CreateDietMealDto>();
    }


    public class CreateDietMealDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Video { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public IEnumerable<CreateIngredientDto> Ingredients { get; set; } = new List<CreateIngredientDto>();
    }

    public class CreateIngredientDto
    {
        public string Name { get; set; } = string.Empty;
        public float Weight { get; set; }
    }

    public class DietPlanResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string TrainerId { get; set; } = string.Empty;
        public IEnumerable<DietMealResponse> Meals { get; set; } = new List<DietMealResponse>();
    }

    public class DietMealResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Video { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public IEnumerable<IngredientResponse> Ingredients { get; set; } = new List<IngredientResponse>();
    }

    public class IngredientResponse
    {
        public string Name { get; set; } = string.Empty;
        public float Weight { get; set; }
    }

    public class UpdateDietPlanDto
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<UpdateDietMealDto> Meals { get; set; } = new List<UpdateDietMealDto>();
    }

    public class UpdateDietMealDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Video { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public IEnumerable<UpdateIngredientDto> Ingredients { get; set; } = new List<UpdateIngredientDto>();
    }

    public class UpdateIngredientDto
    {
        public string Name { get; set; } = string.Empty;
        public float Weight { get; set; }
    }
}