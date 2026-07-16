using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.Domain.Constant;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area(AreaConstants.ADMIN)]
    public class HubTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
