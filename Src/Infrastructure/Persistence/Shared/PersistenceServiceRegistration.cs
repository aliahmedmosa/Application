using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.Shared
{
    public static class PersistenceServiceRegistration
    {
        public static void ConfigurePersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            //Configure Application DbContext
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")?? 
                    throw new InvalidOperationException("Connection string is not found"));
            });

            //Configure Services
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUomRepository, UomRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
        }
    }
}
