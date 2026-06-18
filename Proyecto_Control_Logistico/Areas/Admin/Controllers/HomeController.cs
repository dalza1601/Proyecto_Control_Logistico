using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Domain;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Domain.Enums;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Documents;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories.Interfaces;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;
using Proyecto_Control_Logistico.Models;
using Proyecto_Control_Logistico.UI.MVC.Utils;
using System.Diagnostics;

namespace Proyecto_Control_Logistico.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
        protected readonly IMongoUnitOfWork _unitOfWork;

        public HomeController(IMongoUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        //[HttpPost]
        //public IActionResult Crear(Producto producto)
        //{
        //    return Content("Producto guardado");
        //}

        public IActionResult Privacy()
        {
            if (ModelState.IsValid) { 
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
