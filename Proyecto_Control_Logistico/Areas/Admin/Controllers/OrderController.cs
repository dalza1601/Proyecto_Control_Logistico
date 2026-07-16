using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Application.Interfaces.ICache;
using Proyecto_Control_Logistico.Application.UseCase.OrderUseCase.Command;
using Proyecto_Control_Logistico.Application.UseCase.OrderUseCase.Queries;
using Proyecto_Control_Logistico.Domain.Constant;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Interfaces.IReadExcel;
using Proyecto_Control_Logistico.UI.MVC.ViewModel;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area(AreaConstants.ADMIN)]
    [AllowAnonymous]
    public class OrderController : Controller
    {
        private readonly IOrderReadExcel _orderReadExcel;
        private readonly InsertOrder _insertOrder;
        private readonly GetOrdersQuery _getOrdersQuery;
        private readonly IOrderPreviewCache _previewCache;

        public OrderController(GetOrdersQuery getOrdersQuery, IOrderReadExcel orderReadExcel,
        InsertOrder insertOrder, IOrderPreviewCache previewCache)
        {
            _getOrdersQuery = getOrdersQuery;
            _orderReadExcel = orderReadExcel;
            _insertOrder = insertOrder;
            _previewCache = previewCache;
        }

        public async Task<IActionResult> Index()
        {
            List<OrderDTO> ordersDTO = await _getOrdersQuery.ExecuteAsync();
            var preview = _previewCache.Get();

            return View(new OrderViewModel
            {
                orders = ordersDTO,
                ordersPreview = preview,
                isPreviewView = preview != null
            });
        }

        [HttpPost]
        public async Task<IActionResult> ImportExcel(IFormFile archivoExcel)
        {
            if (archivoExcel == null || archivoExcel.Length == 0)
            {
                TempData["ErrorMessage"] = ExcelConstants.MUST_SELECT_FILE;
                return RedirectToAction(nameof(Index));
            }

            var extension = Path.GetExtension(archivoExcel.FileName);
            if (extension != ".xlsx")
            {
                TempData["ErrorMessage"] = ExcelConstants.INVALID_FILE_TYPE;
                return RedirectToAction(nameof(Index));
            }

            using var stream = archivoExcel.OpenReadStream();
            var result = await _orderReadExcel.ImportOrderFromExcel(stream);
            
            if (result == null)
            {
                TempData["ErrorMessage"] = ExcelConstants.NO_ROWS_FOUND;
                return RedirectToAction(nameof(Index));
            }

            _previewCache.Save(result);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(IFormFile archivoExcel)
        {
            var preview = _previewCache.Get(false);

            if (preview == null)
            {
                TempData["ErrorMessage"] = ExcelConstants.NO_ROWS_FOUND;
                return RedirectToAction(nameof(Index));
            }

            var success = await _insertOrder.ExecuteAsync(preview);
            if (!success)
            {
                TempData["ErrorMessage"] = CommandConstants.FAILED_TO_INSERT_ORDER;
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = CommandConstants.SUCCESS_TO_SAVE_ORDER;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DescartarPreview()
        {
            _previewCache.Clear();
            return RedirectToAction(nameof(Index));
        }
    }
}
