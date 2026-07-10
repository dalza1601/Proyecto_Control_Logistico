using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_Control_Logistico.Application.Interfaces.IHub;
using Proyecto_Control_Logistico.Infrastructure.Services.Inventory;

namespace Proyecto_Control_Logistico.Infrastructure.Services
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Agrega más repositorios según sea necesario
            services.AddScoped<IInventoryNotifier, InventoryNotifier>();

            return services;
        }
    }
}
