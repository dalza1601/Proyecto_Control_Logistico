using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.Application.UseCase.InventoryDashboard.Queries;
using Proyecto_Control_Logistico.Domain.Constant;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area(AreaConstants.ADMIN)]
    public class InventoryDashboardController : Controller
    {
        private readonly GetInventoryDashboardQuery _getInventoryDashboardQuery;

        public InventoryDashboardController(GetInventoryDashboardQuery getInventoryDashboardQuery)
        {
            _getInventoryDashboardQuery = getInventoryDashboardQuery;
        }

        public async Task<IActionResult> Index()
        {
            var dynamicModel = await _getInventoryDashboardQuery.ExecuteAsync();
            return View(dynamicModel);
        }
    }
}
