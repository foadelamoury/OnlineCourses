using Application.Common.Interfaces;
using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        services
          .AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));



        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddTransient<IFileUploadHelper, FileUploadHelper>();
        services.AddTransient<IFileDeleteHelper, FileDeleteHelper>();




        //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);







        return services;
    }

    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        services
          .AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
















        return services;
    }
}
