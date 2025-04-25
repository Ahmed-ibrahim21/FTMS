using FTMS.models.models_for_M_M;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FTMS.models
{
    public class User : IdentityUser
    {
        public bool IsApproved { get; set; } = true;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [MaxLength(1048576)]
        public byte[]? ProfilePic { get; set; }



        public List<UserGroup> UserGroups { get; set; }

        public List<UserChats> UserChats { get; set; }

        public List<DietPlan> DietPlans { get; set; }

        public List<WorkoutPlan> WorkoutPlans { get; set; }

    }
}
