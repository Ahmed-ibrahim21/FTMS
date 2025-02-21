using System.ComponentModel.DataAnnotations;

namespace FTMS.models
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MinLength(11)]
        public string Email { get; set; }
    }
}
