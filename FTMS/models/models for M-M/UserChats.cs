﻿namespace FTMS.models.models_for_M_M
{
    public class UserChats
    {
        public Guid  UserId { get; set; }

        public User User { get; set; }

        public int ChatId { get; set; }

        public Chat Chat { get; set; }
    }
}
