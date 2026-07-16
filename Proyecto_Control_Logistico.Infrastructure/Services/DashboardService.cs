
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Infrastructure.Data;
namespace Proyecto_Control_Logistico.Infrastructure.Services
{
    public class DashboardService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        public DashboardService(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }
        private async Task<int> ObtenerProductos()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Products.CountAsync();
        }
        private async Task<int> ObtenerCategorias()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Categories.CountAsync();
        }
        private async Task<int> ObtenerClientes()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Clients.CountAsync();
        }
        public async Task Dashboard()
        {
            var productosTask = ObtenerProductos();
            var categoriasTask = ObtenerCategorias();
            var clientesTask = ObtenerClientes();
            await Task.WhenAll(
                productosTask,
                categoriasTask,
                clientesTask);
            Console.WriteLine(productosTask.Result);
            Console.WriteLine(categoriasTask.Result);
            Console.WriteLine(clientesTask.Result);
        }
    }
}