using FTMS.models.models_for_M_M;
using System.ComponentModel.DataAnnotations;

namespace FTMS.models
{
    public class DietPlan
    {
        [Key]
       public int PlanId { get; set; }

        public string DietName { get; set; }=string.Empty;

        public List<UserDiets>? UserDiets { get; set; }
    }
}
