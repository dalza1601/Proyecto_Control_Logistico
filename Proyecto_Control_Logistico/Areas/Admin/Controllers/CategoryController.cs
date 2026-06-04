using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Domain.Enums;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;
using Proyecto_Control_Logistico.UI.MVC.Utils;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork unitOfWork, ILogger<BaseController> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAll();

            return View(categories.Select(c => _mapper.Map<CategoryDTO>(c)));
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
            return RedirectToAction(nameof(Index));
        }
    }
}
