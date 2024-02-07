using Microsoft.Net.Http.Headers;

namespace WebAPI.Extensions
{
    /// <summary>
    /// Cors extension
    /// </summary>
    public static class CorsExtensions
    {
        /// <summary>
        /// Configure cors
        /// </summary>
        /// <param name="services">Servie collection</param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("Policy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders(HeaderNames.AccessControlAllowHeaders, HeaderNames.ContentDisposition);
            }));
        }

        /// <summary>
        /// Add corse
        /// </summary>
        /// <param name="app">Web application</param>
        public static void AddCors(this WebApplication app)
        {
            app.UseCors("Policy");
        }
    }
}
