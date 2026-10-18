using GearHub.Infrastructure.Configurations;
using GearHub.Infrastructure.Identity;
using GearHub.Infrastructure.Persistence;
using GearHub.Application.Abstractions;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GearHub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddOptions<DatabaseOptions>().Configure(options =>
        {
            options.ConnectionString = configuration["DATABASE_URL"] ?? string.Empty;
        }).Validate(options => !string.IsNullOrWhiteSpace(options.ConnectionString), "DATABASE_URL is missing.").ValidateOnStart();

        services.AddDbContext<GearHubDbContext>((provider, options) =>
        {
            var databaseOptions = provider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

            options.UseNpgsql(databaseOptions.ConnectionString);
        });

        services.AddIdentityCore<ApplicationUser>(options =>
        {
            options.User.RequireUniqueEmail = true;
        }).AddRoles<IdentityRole<Guid>>().AddEntityFrameworkStores<GearHubDbContext>();

        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }
}