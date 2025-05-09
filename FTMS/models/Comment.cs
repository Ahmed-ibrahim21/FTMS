﻿using System.ComponentModel.DataAnnotations;

namespace FTMS.models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Text { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        public List<Reaction> Reactions { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int PostId { get; set; }  
        public Post Post { get; set; }
    }
}
