using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GuitarShop.Persistence.Extensions
{
    public static class ServiceCollectionExtension
    {
        public async static Task<IServiceCollection> AddDatabase(this IServiceCollection services,
             IConfiguration configuration)
        {
            var connectionString = configuration["Db:DefaultConnectionString"];
            services.AddDbContext<GuitarShopContext>(options =>
                options.UseSqlServer(connectionString, builder =>
                    builder.MigrationsAssembly(typeof(GuitarShopContext).Assembly.FullName)));

            GuitarShopContext context = services.BuildServiceProvider().GetService<GuitarShopContext>();
            await context.MigrateDatabase();
            await context.SeedDatabase();

            return services;
        }
    }
}
