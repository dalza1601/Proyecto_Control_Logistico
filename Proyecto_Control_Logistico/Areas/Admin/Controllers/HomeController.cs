using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.Domain;
using Proyecto_Control_Logistico.Domain.Enums;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;
using Proyecto_Control_Logistico.Models;
using Proyecto_Control_Logistico.UI.MVC.Utils;
using System.Diagnostics;

namespace Proyecto_Control_Logistico.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork unitOfWork, ILogger<BaseController> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
        {
        }

        public IActionResult Index()
        {
            //return Content("{\"message\": \"Hello, World!\"}", "application/json");
            //return Content("<h1>Hello, World!</h1>", "text/html");
            //JObject json = new JObject();
            //json.Add("message", "Hello, World!");
            //return Json(json);

            //return Content("<product> Laptop </product>", "application/xml");
            //return File();
            //return Redirect();
            //return NotFound();

            //Alert("Bienvenido al panel de administración", NotificationType.sucess);
            //AlertDraggable("Bienvenido al panel de administración", TypeIconsNotification.success);
            //AlertTitleTextAndIcon("Bienvenido al panel de administración", "Gracias por utilizar nuestro sistema.", TypeIconsNotification.question);
            //AlertErrorWithFooter(string.Format("Bienvenido al panel de administración"), TypeIconsNotification.error, "Gracias por utilizar nuestro sistema.");
            //AlertWithImage("https://cdn-icons-png.flaticon.com/512/190/190411.png", 100, "Bienvenido");
            //AlertDeleteYesOrNot();
            //Alert(Constants.TypeErrors[TypeIconsNotification.error.ToString()], NotificationType.error);
            return View();

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
