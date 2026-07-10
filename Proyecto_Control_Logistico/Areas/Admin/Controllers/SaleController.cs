using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Domain.Constant;
using Proyecto_Control_Logistico.Domain.Enums;
using Proyecto_Control_Logistico.Domain.Entities;
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
            var sale = await _unitOfWork.SaleRepository.GetFirstOrDefault(
                sale => sale.Id == id,
                includeProperties: "SaleDetails"
            );

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

            await RestoreInventoryAsync(sale);
            await _unitOfWork.SaleRepository.Update(sale);
            await _unitOfWork.SaveAsync();

            AlertTitleTextAndIcon(
                "Venta anulada",
                "La venta ha sido anulada correctamente.",
                TypeIconsNotification.success
            );

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsReviewed(int id)
        {
            var sale = await _unitOfWork.SaleRepository.GetFirstOrDefault(
                sale => sale.Id == id,
                includeProperties: "SaleDetails"
            );

            if (sale == null)
            {
                return NotFound();
            }

            if (sale.Status != "Registrado")
            {
                AlertTitleTextAndIcon(
                    "Estado no actualizado",
                    "Solo una venta registrada puede pasar a revisado.",
                    TypeIconsNotification.warning
                );

                return RedirectToAction(nameof(Details), new { id });
            }

            var hasStock = await HasStockAvailableAsync(sale);

            if (!hasStock)
            {
                AlertTitleTextAndIcon(
                    "Stock insuficiente",
                    "No hay stock suficiente para revisar esta venta.",
                    TypeIconsNotification.warning
                );

                return RedirectToAction(nameof(Details), new { id });
            }

            sale.Status = "Revisado";
            sale.UpdatedAt = DateTime.Now;

            await DiscountInventoryAsync(sale);
            await _unitOfWork.SaleRepository.Update(sale);
            await _unitOfWork.SaveAsync();

            AlertTitleTextAndIcon(
                "Venta revisada",
                "La venta fue revisada y el stock fue reservado correctamente.",
                TypeIconsNotification.success
            );

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsPendingShipment(int id)
        {
            var sale = await _unitOfWork.SaleRepository.GetByIdAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            if (sale.Status != "Revisado")
            {
                AlertTitleTextAndIcon(
                    "Estado no actualizado",
                    "Solo una venta revisada puede pasar a pendiente de envío.",
                    TypeIconsNotification.warning
                );

                return RedirectToAction(nameof(Details), new { id });
            }

            sale.Status = "Pendiente de envio";
            sale.UpdatedAt = DateTime.Now;

            await _unitOfWork.SaleRepository.Update(sale);
            await _unitOfWork.SaveAsync();

            AlertTitleTextAndIcon(
                "Venta pendiente de envío",
                "La venta cambió a pendiente de envío.",
                TypeIconsNotification.success
            );

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsDelivered(int id)
        {
            var sale = await _unitOfWork.SaleRepository.GetByIdAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            if (sale.Status != "Pendiente de envio" && sale.Status != "Pendiente de envío")
            {
                AlertTitleTextAndIcon(
                    "Estado no actualizado",
                    "Solo una venta pendiente de envío puede pasar a entregado.",
                    TypeIconsNotification.warning
                );

                return RedirectToAction(nameof(Details), new { id });
            }

            sale.Status = "Entregado";
            sale.UpdatedAt = DateTime.Now;

            await _unitOfWork.SaleRepository.Update(sale);
            await _unitOfWork.SaveAsync();

            AlertTitleTextAndIcon(
                "Venta entregada",
                "La venta cambió a estado Entregado.",
                TypeIconsNotification.success
            );

            return RedirectToAction(nameof(Details), new { id });
        }

        private async Task<bool> HasStockAvailableAsync(Sale sale)
        {
            foreach (var detail in sale.SaleDetails)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(detail.ProductId);

                if (product == null || product.Stock < detail.Quantity)
                {
                    return false;
                }
            }

            return true;
        }
        private async Task DiscountInventoryAsync(Sale sale)
        {
            foreach (var detail in sale.SaleDetails)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(detail.ProductId);

                if (product == null)
                {
                    continue;
                }
                var lastStock = product.Stock;
                product.Stock -= (int)detail.Quantity;
                product.UpdatedAt = DateTime.Now;

                await _unitOfWork.ProductRepository.Update(product);
                await RegisterInventoryMovement(
                detail.ProductId,
                detail.Quantity,
                lastStock,
                product.Stock,
                "Salida",
                $"Venta {sale.NumberSale}"
            );
            }
        }
        private async Task RestoreInventoryAsync(Sale sale)
        {
            foreach (var detail in sale.SaleDetails)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(detail.ProductId);

                if (product == null)
                {
                    continue;
                }
                var lastStock = product.Stock;
                product.Stock += (int)detail.Quantity;
                product.UpdatedAt = DateTime.Now;

                await _unitOfWork.ProductRepository.Update(product);
                await RegisterInventoryMovement(
                detail.ProductId,
                detail.Quantity,
                lastStock,
                product.Stock,
                "Entrada",
                $"Anulación de venta {sale.NumberSale}"
            );
            }
        }
        private async Task RegisterInventoryMovement(
            int productId,
            decimal quantity,
            decimal lastStock,
            decimal stockAvailable,
            string movementType,
            string motive)
        {
            var inventory = await _unitOfWork.InventoryRepository.GetByProductAsync(productId);
            var warehouseId = inventory?.WarehouseId ?? 1;

            if (inventory != null)
            {
                inventory.Product = null;
                inventory.Warehouse = null;
                inventory.StockAvailable = (int)stockAvailable;
                inventory.LastUpdated = DateTime.Now;
                inventory.UpdatedAt = DateTime.Now;

                await _unitOfWork.InventoryRepository.Update(inventory);
            }

            await _unitOfWork.MovementInventory.AddAsync(new MovementInventory
            {
                ProductId = productId,
                WareHouseId = warehouseId,
                MovementType = movementType,
                Quantity = quantity,
                LastStock = lastStock,
                StockAvailable = stockAvailable,
                Motive = motive,
                CreatedAt = DateTime.Now
            });
        }

    }
}
