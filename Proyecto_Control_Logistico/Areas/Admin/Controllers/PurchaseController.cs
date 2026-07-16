using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;
using Proyecto_Control_Logistico.UI.MVC.Utils;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PurchaseController : BaseController
    {

        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseController(IUnitOfWork unitOfWork, ILogger<BaseController> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
        {
            //_purchaseRepository = purchaseRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Articulos = await _unitOfWork.ProductRepository.GetProductActivesAsync();

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliers = (await _unitOfWork.SupplierRepository.GetAll())
                .Where(x => x.Active)
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    id = x.Id,
                    text = x.Name
                })
                .ToList();
            return Json(suppliers);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Purchase model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //if (_purchaseRepository == null)
            //{
            //    throw new Exception("_purchaseRepository es null");
            //}

            //await _purchaseRepository.SaveAsync(model);
            await _unitOfWork.SaveAsync();

            return Ok(new
            {
                success = true,
                message = "Compra registrada correctamente."
            });
        }
    }
}
