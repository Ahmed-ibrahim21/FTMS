using FTMS.models.models_for_M_M;
using System.ComponentModel.DataAnnotations;

namespace FTMS.models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string GroupName { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPrivate { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedByUserId { get; set; } = string.Empty;
        List<Post>? Posts { get; set; }

        public List<UserGroup>? UserGroups { get; set; }

    }
}
