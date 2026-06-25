using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Domain.Enums;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;
using Proyecto_Control_Logistico.UI.MVC.Utils;
using System.Xml.XPath;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork unitOfWork, ILogger<BaseController> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var category = new CategoryDTO();
            return PartialView("_Create", category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryDto);
                await _unitOfWork.CategoryRepository.AddAsync(category);
                await _unitOfWork.SaveAsync();
                AlertTitleTextAndIcon("Categoría creada", "La categoría ha sido creada exitosamente.", TypeIconsNotification.success);
            }
            return Json(new { success = true, message = "Categoría creada exitosamente." });
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategories() {
            var draw = Request.Query["draw"].FirstOrDefault();
            var searchValue = Request.Query["search[value]"].FirstOrDefault()?.ToLower();
            var start = Convert.ToInt32(Request.Query["start"].FirstOrDefault());
            var length = Convert.ToInt32(Request.Query["length"].FirstOrDefault());

            var query = await _unitOfWork.CategoryRepository.GetAll();
            var recordsTotal = await query.CountAsync();

            if (!string.IsNullOrEmpty(searchValue))
                query = query.Where(c => EF.Functions.Like(c.Name, $"%{searchValue}%"));
                //query = query.Where(c => c.Name.ToLower().Contains(searchValue.ToLower()));

            //Liberamos el dbcontext para evitar problemas de tracking y rendimiento
            var filteredList = await query.ToListAsync();

            var recordsFiltered = filteredList.Count();

            var categories  = filteredList.OrderBy(c => c.Id)
                .Skip(start)
                .Take(length)
                .Select(c => _mapper.Map<CategoryDTO>(c))
                .ToList();
            
            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = categories });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound(new { message = "Categoría no encontrada" });
            }
            return PartialView("_Edit", _mapper.Map<CategoryDTO>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(new { message = "Categoría no encontrada" });
                }

                _mapper.Map(categoryDto, category);
                await _unitOfWork.CategoryRepository.Update(category);
                await _unitOfWork.SaveAsync();
                AlertTitleTextAndIcon("Categoría actualizada", "La categoría ha sido actualizada exitosamente.", TypeIconsNotification.success);
            }
            return Json(new { success = true, message = "Categoría actualizada exitosamente." });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound(new { message = "Categoría no encontrada" });
            }

            await _unitOfWork.CategoryRepository.Remove(category);
            await _unitOfWork.SaveAsync();
            AlertTitleTextAndIcon("Categoría eliminada", "La categoría ha sido eliminada exitosamente.", TypeIconsNotification.success);
            return Json(new { success = true, message = "Categoría eliminada exitosamente." });
        }
    }
}
