using FTMS.models;
using FTMS.models.models_for_M_M;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FTMS
{
    public class FTMSContext : IdentityDbContext<User>
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<DietPlan> DietPlans { get; set; }

        public DbSet<FriendRequest> FriendRequests { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Post> posts { get; set; }

        public DbSet<Rating> Rating { get; set; }

        public DbSet<Reaction> Reactions { get; set; }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<UserChats> UserChats { get; set; }

        public DbSet<UserDiets> UserDiets { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }


        public FTMSContext(DbContextOptions<FTMSContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserChats>().HasKey(uc => new { uc.UserId, uc.ChatId });
            builder.Entity<UserDiets>().HasKey(uc => new { uc.UserId, uc.DietId });
            builder.Entity<UserGroup>().HasKey(uc => new { uc.UserId, uc.GroupId });


            base.OnModelCreating(builder);
        }
    }
}
