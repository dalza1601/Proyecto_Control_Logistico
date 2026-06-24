using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Interfaces;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Models;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Documents;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories.Interfaces;
using Proyecto_Control_Logistico.Models;
using System.Diagnostics;

namespace Proyecto_Control_Logistico.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
        protected readonly IMongoUnitOfWork _unitOfWork;
        private readonly IExcelService _excelService;

        public HomeController(IMongoUnitOfWork unitOfWork, IExcelService excelService)
        {
            _unitOfWork = unitOfWork;
            _excelService = excelService;
        }

        [HttpGet]
        public async Task<IActionResult> ExportExcel()
        {
            var categories = await _unitOfWork.MongoCategoryRepository.GetAllAsync();

            var columns = new List<ExcelColumn<CategoryDocument>> {
                new() { Header = "Id", ValueSelector = x => x.Id},
                new() { Header = "Name", ValueSelector = x => x.name},
                new() { Header = "Description", ValueSelector = x => x.description}
            };

            var fileBytes = await _excelService.ExportToExcel(categories, "Categorias", columns);

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteCategoria.xlsx");
        }

        [HttpPost]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {

            var extension = Path.GetExtension(file.FileName);
            if (extension != ".xlsx")
            {
                return BadRequest("Solo se permiten archivos .xlsx");
            }

            if (file == null || file.Length == 0)
                return BadRequest("Debe seleccionar un archivo");

            using var stream = file.OpenReadStream();

            var categories = _excelService.ImportFromExcel<CategoryDocument>(stream, new List<ExcelImportColumn<CategoryDocument>>() {
            new() {
                Header = "Id",
                SetValue = (x,value) => x.Id = value?.ToString() ?? string.Empty
            },
            new() {
                Header = "Name",
                SetValue = (x,value) => x.name = value?.ToString() ?? string.Empty
            },
            new() {
                Header = "Description",
                SetValue = (x,value) => x.description = value?.ToString() ?? string.Empty
            }
            });

            return Json(categories);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Json(new { data = await _unitOfWork.MongoCategoryRepository.GetAllAsync() });
        }
        public async Task<IActionResult> Create()
        {
            var category = new CategoryDocument();
            return PartialView("_Create", category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDocument categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.MongoCategoryRepository.AddAsync(categoryDto);
            }
            return Json(new { success = true, message = "Categoría creada exitosamente." });
        }

        public IActionResult Saludo(string nombre)
        {
            return Content($"Hola, {nombre}!", "text/plain");
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            if (ModelState.IsValid)
            {
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
