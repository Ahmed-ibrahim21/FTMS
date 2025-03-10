﻿using FTMS.Repositories;
using FTMS.RepositoriesContracts;

namespace FTMS.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
       services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
