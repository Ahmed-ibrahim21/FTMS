using FTMS.models.models_for_M_M;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FTMS.models
{
    public class User : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [MaxLength(1048576)]
        public byte[] ProfilePic { get; set; }


        public List<Chat> chats { get; set; }

        public List<DietPlan> dietPlans {  get; set; }

        public List<UserGroup> UserGroups { get; set; }

        public List<UserChats> UserChats { get; set; }

        public List<UserDiets> UserDiets { get; set; }

    }
}
