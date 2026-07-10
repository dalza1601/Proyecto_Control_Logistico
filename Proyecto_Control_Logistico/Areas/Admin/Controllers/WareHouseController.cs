using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Domain.Constant;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Domain.Enums;
using Proyecto_Control_Logistico.UI.MVC.Utils;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area(AreaConstants.ADMIN)]
    public class WareHouseController : BaseController
    {
        public WareHouseController(IUnitOfWork unitOfWork, ILogger<BaseController> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWareHouses()
        {
            var draw = Request.Query["draw"].FirstOrDefault();
            var searchValue = Request.Query["search[value]"].FirstOrDefault()?.ToLower();
            var start = Convert.ToInt32(Request.Query["start"].FirstOrDefault());
            var length = Convert.ToInt32(Request.Query["length"].FirstOrDefault());

            var query = await _unitOfWork.WareHouseRepository.GetAll(filter: Warehouse => Warehouse.Active);
            var recordsTotal = await query.CountAsync();

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(c => EF.Functions.Like(c.Name.ToLower(), $"%{searchValue}%"));
            }

            var filteredList = await query.ToListAsync();

            var recordsFiltered = filteredList.Count();

            var clients = filteredList.Where(x => x.Active)
                .OrderBy(c => c.Id)
                .Skip(start)
                .Take(length)
                .Select(c => _mapper.Map<WareHouseDTO>(c))
                .ToList();

            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = clients });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return PartialView("_Create", new WareHouseDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WareHouseDTO wareHouseDTO)
        {
            if (ModelState.IsValid)
            {
                var warehouse = _mapper.Map<Warehouse>(wareHouseDTO);
                warehouse.UpdatedAt = DateTime.Now;
                await _unitOfWork.WareHouseRepository.AddAsync(warehouse);
                await _unitOfWork.SaveAsync();
                AlertTitleTextAndIcon("Almacén registrado", "El almacén ha sido registrado exitosamente.", TypeIconsNotification.success);
            }
            return Json(new { success = true, message = "Almacén registrado exitosamente." });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var warehouse = await _unitOfWork.WareHouseRepository.GetByIdAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            var warehouseDTO = _mapper.Map<WareHouseDTO>(warehouse);
            return PartialView("_Edit", warehouseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, WareHouseDTO wareHouseDTO)
        {
            if (ModelState.IsValid)
            {
                var warehouse = await _unitOfWork.WareHouseRepository.GetByIdAsync(id);
                if (warehouse == null)
                {
                    return NotFound();
                }
                _mapper.Map(wareHouseDTO, warehouse);
                warehouse.UpdatedAt = DateTime.Now;
                await _unitOfWork.SaveAsync();
                AlertTitleTextAndIcon("Almacén actualizado", "El almacén ha sido actualizado exitosamente.", TypeIconsNotification.success);
            }
            return Json(new { success = true, message = "Almacén actualizado exitosamente." });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var warehouse = await _unitOfWork.WareHouseRepository.GetByIdAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            warehouse.Active = false;
            warehouse.UpdatedAt = DateTime.Now;
            await _unitOfWork.SaveAsync();
            AlertTitleTextAndIcon("Almacén deshabilitado", "El almacén ha sido deshabilitado exitosamente.", TypeIconsNotification.success);
            return Json(new { success = true, message = "Almacén deshabilitado exitosamente." });
        }
    }
}
