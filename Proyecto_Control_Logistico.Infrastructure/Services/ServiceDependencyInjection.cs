using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_Control_Logistico.Application.Interfaces.ICache;
using Proyecto_Control_Logistico.Application.Interfaces.IHub;
using Proyecto_Control_Logistico.Infrastructure.Services.Cache;
using Proyecto_Control_Logistico.Infrastructure.Services.Inventory;

namespace Proyecto_Control_Logistico.Infrastructure.Services
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddAuxiliaryInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Agrega más repositorios según sea necesario
            services.AddScoped<IInventoryNotifier, InventoryNotifier>();
            services.AddScoped<IOrderPreviewCache, OrderPreviewCache>();

            return services;
        }
    }
}
