using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Travel.Application.Common.Interfaces;
using Travel.Data.Contexts;

namespace Travel.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureData(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql("host=localhost;database=travelapp_dev;username=postgres;password=devapplication"));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        return services;
    }
}