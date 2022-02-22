using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Contracts;
using Products.Data;
using Products.Repository;

namespace Products_API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDbContext<ProductsContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b =>
            b.MigrationsAssembly("Products.API")));

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
