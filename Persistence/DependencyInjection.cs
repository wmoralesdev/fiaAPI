using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FIADbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultDbConnection"));
                options.UseLazyLoadingProxies();
            });

            services.AddScoped<IFIADbContext, FIADbContext>();
            return services;
        }

        public static void MigrateContext(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<FIADbContext>();
            context.Database.Migrate();
        }
    }
}
