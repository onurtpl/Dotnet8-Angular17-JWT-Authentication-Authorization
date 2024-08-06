using Domain.Entities.IdentityEntities;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Configurations;

internal static class InfrastructureConfigurations
{
    internal static void AddInfrastructureConfigurations(
        this IServiceCollection services,
        IConfigurationManager configuration,
        IHostBuilder host)
    {
        services.AddAutoMapper(typeof(InfrastructureAssembly).Assembly);
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }
}
