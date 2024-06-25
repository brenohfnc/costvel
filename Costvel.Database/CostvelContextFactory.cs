using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Costvel.Database;

public class CostvelContextFactory : IDesignTimeDbContextFactory<CostvelContext>
{
    public CostvelContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CostvelContext>();

        optionsBuilder
            .UseNpgsql(args[0])
            .UseLazyLoadingProxies();

        return new CostvelContext(optionsBuilder.Options);
    }
}