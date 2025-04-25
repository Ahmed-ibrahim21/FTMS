using System.ComponentModel.DataAnnotations.Schema;

namespace FTMS.models
{
    public class DietMeal
    {
       public int id { get; set; }
       public int dietPlanId { get; set; }

        [ForeignKey("dietPlanId")]
        public DietPlan dietPlan { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public string? Video { get; set; } = string.Empty;

        public byte[]? Image { get; set; }

        public List<Ingredients> ingredients { get; set; }

    }
}
