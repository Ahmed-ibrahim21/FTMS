using System.ComponentModel.DataAnnotations.Schema;

namespace FTMS.models
{
    public class Ingredients
    {
        public int id {  get; set; }
        public string Name { get; set; }

        public float weight {  get; set; }

        public int DietMealId { get; set; }

        [ForeignKey("DietMealId")]
        public DietMeal DietMeal { get; set; }
    }
}
