using Microsoft.Extensions.DependencyInjection;
using Proyecto_Control_Logistico.Application.UseCase.InventoryDashboard.Queries;

namespace Proyecto_Control_Logistico.Application.UseCase
{
    public static class UseCaseDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Aquí registras tus casos de uso como servicios Scoped
            services.AddScoped<GetInventoryDashboardQuery>();

            return services;
        }
    }
}
