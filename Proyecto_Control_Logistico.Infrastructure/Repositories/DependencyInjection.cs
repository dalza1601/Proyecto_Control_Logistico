using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Infrastructure.Repositories.Repository;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Aquí agrupas repositories
            services.AddScoped<IMovementInventoryRepository, MovementInventoryRepository>();
            services.AddScoped<IWareHouseRepository, WareHouseRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
