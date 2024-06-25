using Costvel.Database;
using Microsoft.EntityFrameworkCore;

namespace Costvel.Api.Extensions;

public static class WebApplicationExtensions
{
    public static async Task UseMigration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<CostvelContext>();

        await context.Database.MigrateAsync();
        await context.Database.EnsureCreatedAsync();
    }
}