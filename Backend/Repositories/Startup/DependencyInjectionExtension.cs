using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace Repositories.Startup
{
    public static class DependencyInjectionExtension
    {
        public static async Task AutoUpdateContextAsync(this IServiceProvider app)
        {
            using var scope = app.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<EntityContext>();

            var pendingMigrations = await db.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                await db.Database.MigrateAsync();
            }

        }
    }
}
