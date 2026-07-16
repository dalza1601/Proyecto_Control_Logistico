using Microsoft.Extensions.DependencyInjection;
using Proyecto_Control_Logistico.Application.UseCase.InventoryDashboard.Queries;
using Proyecto_Control_Logistico.Application.UseCase.OrderUseCase.Command;
using Proyecto_Control_Logistico.Application.UseCase.OrderUseCase.Queries;

namespace Proyecto_Control_Logistico.Application.UseCase
{
    public static class UseCaseDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Aquí registras tus casos de uso como servicios Scoped
            services.AddScoped<GetInventoryDashboardQuery>();
            services.AddScoped<InsertOrder>();
            services.AddScoped<GetOrdersQuery>();

            return services;
        }
    }
}
