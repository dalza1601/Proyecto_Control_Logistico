using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Infrastructure.Repositories.Repository;
using Proyecto_Control_Logistico.UI.MVC.ViewModel;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var dashboardVm = new DashboardViewModel();
            var productosActivos = await _unitOfWork.ProductRepository.GetProductActivesAsync();

            dashboardVm.ProductosBajoStock = productosActivos
                .Where(p => p.Stock < 20)
                .OrderBy(p => p.Stock)
                .ToList();

            dashboardVm.Top10Productos = productosActivos.OrderByDescending(p => p.PriceSell).Take(10).ToList();
            dashboardVm.ProductosSinVender = productosActivos.Where(p => p.Stock > 50).Take(5).ToList();

            var ordenesQuery = await _unitOfWork.OrderRepository.GetAll();
            var ordenesCompra = await ordenesQuery.ToListAsync();

            var comprasAgrupadas = ordenesCompra
                .GroupBy(o => o.DateOrder.Month)
                .OrderBy(g => g.Key) 
                .Select(g => new {
                    Mes = new DateTime(DateTime.Now.Year, g.Key, 1).ToString("MMMM").ToUpper(),
                    Total = g.Sum(o => o.TotalAmount)
                })
                .ToList();

            dashboardVm.MesesCompras = comprasAgrupadas.Select(c => c.Mes).ToList();
            dashboardVm.TotalesCompras = comprasAgrupadas.Select(c => c.Total).ToList();

            return View(dashboardVm);
        }
    }
}