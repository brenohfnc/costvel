using Costvel.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Costvel.Database;

public class CostvelContext(DbContextOptions<CostvelContext> options) : DbContext(options)
{
    public DbSet<Location> Locations { get; init; }

    public DbSet<Cost> Costs { get; init; }

    public DbSet<CostType> CostTypes { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CostvelContext).Assembly);
    }
}