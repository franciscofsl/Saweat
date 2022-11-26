using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Saweat.Application.Contracts.Common;
using Saweat.Infrastructure.Persistence;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            sqlServerOptionsAction: builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
