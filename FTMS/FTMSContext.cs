using FTMS.models;
using FTMS.models.models_for_M_M;
using Microsoft.AspNetCore.Identity;
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

        public DbSet<DietMeal> dietMeals { get; set; }

        public DbSet<Ingredients> Ingredients { get; set; }

        public DbSet<FriendRequest> FriendRequests { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Post> posts { get; set; }

        public DbSet<Rating> Rating { get; set; }

        public DbSet<Reaction> Reactions { get; set; }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<UserChats> UserChats { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }

        public DbSet<workoutMove> workoutMoves { get; set; }


        public FTMSContext(DbContextOptions<FTMSContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserChats>().HasKey(uc => new { uc.UserId, uc.ChatId });
            builder.Entity<UserDiets>().HasKey(uc => new { uc.UserId, uc.DietId });
            builder.Entity<UserGroup>().HasKey(uc => new { uc.UserId, uc.GroupId });

            //builder.Entity<FriendRequest>()
            //    .HasOne<User>()
            //    .WithMany()
            //    .HasForeignKey(f => f.SenderId)
            //    .OnDelete(DeleteBehavior.Restrict); 

            //builder.Entity<FriendRequest>()
            //    .HasOne<User>()
            //    .WithMany()
            //    .HasForeignKey(f => f.ReceiverId)
            //    .OnDelete(DeleteBehavior.Cascade);



            var adminRoleId = "DDC16163-28DC-4325-BECE-56A2B5BBE8E0"; // Fixed GUID
            var userRoleId = "31C0AC99-29F4-4A55-AF0F-07402617FC47"; // Fixed GUID
            var trainerRoleId = "C1DA0795-351E-45E3-8C4F-74DA1438BB50"; // Fixed GUID
            var adminUserId = "0BE7B103-1D31-420F-853C-EE3BC9236FB4"; // Fixed GUID

            var roles = new List<IdentityRole>
            {
                new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "USER" },
                new IdentityRole { Id = trainerRoleId, Name = "Trainer", NormalizedName = "TRAINER" }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Create admin user
            var adminEmail = "admin@gmail.com";
            var adminPassword = "Admin@123"; 

            var hasher = new PasswordHasher<User>();
            var adminUser = new User
            {
                Id = adminUserId,
                UserName = adminEmail,
                NormalizedUserName = adminEmail.ToUpper(),
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "Admin",
                ProfilePic = new byte[0], 
                PasswordHash = hasher.HashPassword(null, adminPassword)
            };
            builder.Entity<User>().HasData(adminUser);

            
            var adminUserRole = new IdentityUserRole<string>
            {
                UserId = adminUserId,
                RoleId = adminRoleId
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);

            base.OnModelCreating(builder);
        }
    }
}
