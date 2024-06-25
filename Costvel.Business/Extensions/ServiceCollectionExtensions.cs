using Costvel.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Costvel.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureDatabase(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<CostvelContext>((provider, options) =>
        {
            var configuration = provider.GetService<IConfiguration>();
            var connectionString = configuration.GetSection("Database:ConnectionString").Value;

            options
                .UseNpgsql(connectionString)
                .UseLazyLoadingProxies();
        });
    }

    public static void ConfigureBusiness(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<LocationsManager>();
        serviceCollection.AddTransient<CostsManager>();
    }
}