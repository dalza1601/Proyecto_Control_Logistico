using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Domain.Constant;
using Proyecto_Control_Logistico.Domain.Enums;
using Proyecto_Control_Logistico.UI.MVC.Utils;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area(AreaConstants.ADMIN)]
    public class SaleController : BaseController
    {
        public SaleController(IUnitOfWork unitOfWork, ILogger<BaseController> logger, IMapper mapper)
            : base(unitOfWork, logger, mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            var query = await _unitOfWork.SaleRepository.GetAll(includeProperties: "Client");

            var sales = await query
                .OrderByDescending(sale => sale.DateSale)
                .ToListAsync();

            var saleDTOs = sales.Select(sale => _mapper.Map<SaleDTO>(sale));

            return View(saleDTOs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var sale = await _unitOfWork.SaleRepository.GetFirstOrDefault(
                sale => sale.Id == id,
                includeProperties: "Client,SaleDetails.Product"
            );

            if (sale == null)
            {
                return NotFound();
            }

            var saleDTO = _mapper.Map<SaleDTO>(sale);

            return View(saleDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            var sale = await _unitOfWork.SaleRepository.GetByIdAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            if (sale.Status != "Pendiente de envio" && sale.Status != "Pendiente de envío")
            {
                AlertTitleTextAndIcon(
                    "Venta no anulada",
                    "Solo se puede anular una venta en estado pendiente de envío.",
                    TypeIconsNotification.warning
                );

                return RedirectToAction(nameof(Details), new { id });
            }

            sale.Status = "Anulado";
            sale.UpdatedAt = DateTime.Now;

            await _unitOfWork.SaleRepository.Update(sale);
            await _unitOfWork.SaveAsync();

            AlertTitleTextAndIcon(
                "Venta anulada",
                "La venta ha sido anulada correctamente.",
                TypeIconsNotification.success
            );

            return RedirectToAction(nameof(Index));
        }
    }
}