using Microsoft.EntityFrameworkCore;
using PintosTechnicalApp.Config;
using PintosTechnicalApp.Implements.Repositories;
using PintosTechnicalApp.Implements.Services;
using PintosTechnicalApp.Interfaces;
using PintosTechnicalApp.Interfaces.Repositories;
using PintosTechnicalApp.Interfaces.Services;

namespace PintosTechnicalApp;

public static class DependencyInjection
{
    [Obsolete]
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options
            .UseMySQL(
            configuration.GetConnectionString("MySQLConnection"),
            b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        services.AddTransient<IAppDbContext>(provider => provider.GetService<AppDbContext>());
        services.AddAutoMapper(typeof(MappingProfileService));
        services.AddScoped<IPlayerService, PlayerService>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<ITeamService, TeamService>();
        services.AddScoped<ITeamRepository, TeamRepository>();

        return services;
    }
}
