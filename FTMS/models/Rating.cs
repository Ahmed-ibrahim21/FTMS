using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTMS.models
{
    public class Rating
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(0, 5)]
        public int RatingValue { get; set; }

        public string TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public Trainer Trainer { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
