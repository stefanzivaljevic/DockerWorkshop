using Microsoft.EntityFrameworkCore;
using Models;
using Repositories;

namespace WebAPI.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ColorsRepository>();
            services.AddDbContext<EntityContext>(options =>
            options.UseNpgsql(connectionString));
        }

        public static async Task AutoUpdateDatabaseContextAsync(this IServiceProvider app)
        {
            await Repositories.Startup.DependencyInjectionExtension.AutoUpdateContextAsync(app);
        }
    }
}
