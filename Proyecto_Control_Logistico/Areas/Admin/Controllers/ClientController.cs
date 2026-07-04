using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;
using Proyecto_Control_Logistico.UI.MVC.Utils;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ClientController : BaseController
    {
        public ClientController(IUnitOfWork unitOfWork, ILogger<BaseController> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
