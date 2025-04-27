using AspNetCoreRateLimit;
using CaloriePredictionAPI.Services;
using FTMS;
using FTMS.Configuration;
using FTMS.DTOs;
using FTMS.Extensions;
using FTMS.Helper;
using FTMS.Hubs;
using FTMS.models;
using FTMS.Repositories;
using FTMS.RepositoriesContracts;

using FTMS.ServiceContracts;
using FTMS.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCors();

builder.Services.AddSignalR();

builder.Services.ConfigureRepositoryManager();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<FTMSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GP")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<FTMSContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddMemoryCache();
builder.Services.Configure<FlaskApiSettings>(builder.Configuration.GetSection("FlaskApi"));
builder.Services.AddHttpClient<FlaskCalorieService>((serviceProvider, client) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    client.BaseAddress = new Uri(configuration["FlaskApi:BaseUrl"]);

    // You can configure additional HttpClient settings here if needed
    client.Timeout = TimeSpan.FromSeconds(30);
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
});

// Register the FlaskCalorieService
builder.Services.AddScoped<FlaskCalorieService>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IUserGroupRepository, UserGroupRepository>();
builder.Services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();
builder.Services.AddScoped<IFriendRequestService, FriendRequestService>();




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
            "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
            "Example: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                    }
                     });

});
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

builder.Services.AddScoped<JwtService>();
builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IReactionRepository, ReactionRepository>();
builder.Services.AddScoped<IReactionService, ReactionService>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IChatService, ChatService>();

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<IDietPlanRepository, DietplanRepository>();
builder.Services.AddScoped<IDietplanService, DietPlanService>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
    };
});
builder.Services.AddAuthorization();
builder.Services.AddAutoMapper(typeof(MappingProfile));



var app = builder.Build();



app.UseIpRateLimiting();
app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  
app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("/chatHub", options => {
    options.Transports = HttpTransportType.WebSockets;
    options.WebSockets.CloseTimeout = TimeSpan.FromSeconds(30);
});
app.MapHub<ReactionHub>("/reactionHub");
app.MapHub<FriendRequestHub>("/friendRequestHub");


app.MapControllers();

app.Run();
