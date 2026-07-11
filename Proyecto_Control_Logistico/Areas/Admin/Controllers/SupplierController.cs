using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Domain.Enums;
using Proyecto_Control_Logistico.UI.MVC.Utils;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SupplierController : BaseController
    {
        public SupplierController(IUnitOfWork unitOfWork, ILogger<BaseController> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var supplier = new SupplierDTO();
            return PartialView("_Create", supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierDTO supplierDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var supplier = _mapper.Map<Supplier>(supplierDto);
                    supplier.CreatedAt = DateTime.Now;

                    await _unitOfWork.SupplierRepository.AddAsync(supplier);
                    await _unitOfWork.SaveAsync();
                    AlertTitleTextAndIcon("Proveedor creado", "El Proveedor ha sido creada exitosamente.", TypeIconsNotification.success);

                }
                return Json(new { success = true, message = "Proveedor creada exitosamente." });
            }
            catch (Exception ex)
            {
                AlertTitleTextAndIcon("Error al Grabar", ex.Message, TypeIconsNotification.warning);
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var draw = Request.Query["draw"].FirstOrDefault();
            var searchValue = Request.Query["search[value]"].FirstOrDefault()?.ToLower();
            var start = Convert.ToInt32(Request.Query["start"].FirstOrDefault());
            var length = Convert.ToInt32(Request.Query["length"].FirstOrDefault());

            var query = (await _unitOfWork.SupplierRepository.GetAll())
                   .Where(x => x.Active);

            var recordsTotal = await query.CountAsync();

            if (!string.IsNullOrEmpty(searchValue))
                query = query.Where(c => EF.Functions.Like(c.Name, $"%{searchValue}%"));
            //query = query.Where(c => c.Name.ToLower().Contains(searchValue.ToLower()));

            //Liberamos el dbcontext para evitar problemas de tracking y rendimiento
            var filteredList = await query.ToListAsync();

            var recordsFiltered = filteredList.Count();

            var suppliers = filteredList.OrderBy(c => c.Id)
                .Skip(start)
                .Take(length)
                .Select(c => _mapper.Map<SupplierDTO>(c))
                .ToList();

            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = suppliers });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var supplier = await _unitOfWork.SupplierRepository.GetByIdAsync(id);
            if (supplier == null)
            {
                return NotFound(new { message = "Proveedor no encontrada" });
            }
            return PartialView("_Edit", _mapper.Map<SupplierDTO>(supplier));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SupplierDTO supplierDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var supplier = await _unitOfWork.SupplierRepository.GetByIdAsync(id);

                    if (supplier == null)
                        return NotFound();

                    _mapper.Map(supplierDto, supplier);

                    supplier.UpdatedAt = DateTime.Now;

                    await _unitOfWork.SupplierRepository.Update(supplier);
                    await _unitOfWork.SaveAsync();
                    AlertTitleTextAndIcon("Proveedor actualizada", "El Proveedor ha sido actualizada exitosamente.", TypeIconsNotification.success);
                }
                return Json(new { success = true, message = "Proveedor actualizada exitosamente." });
            }
            catch (Exception ex)
            {
                AlertTitleTextAndIcon("Error al Eliminar", ex.Message, TypeIconsNotification.warning);
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var supplier = await _unitOfWork.SupplierRepository.GetByIdAsync(id);
                if (supplier == null)
                {
                    return NotFound(new { message = "Proveedor no encontrada" });
                }
                supplier.Active = false;
                supplier.UpdatedAt = DateTime.Now;

                await _unitOfWork.SupplierRepository.Update(supplier);
                await _unitOfWork.SaveAsync();

                AlertTitleTextAndIcon("Proveedor eliminada", "El Proveedor ha sido eliminada exitosamente.", TypeIconsNotification.success);
                return Json(new { success = true, message = "Proveedor eliminada exitosamente." });

            }
            catch (Exception ex)
            {
                AlertTitleTextAndIcon("Error al Eliminar", ex.Message, TypeIconsNotification.warning);
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
