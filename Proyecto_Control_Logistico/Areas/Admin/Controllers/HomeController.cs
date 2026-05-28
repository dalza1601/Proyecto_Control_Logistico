using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.Models;
using System.Diagnostics;

namespace Proyecto_Control_Logistico.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
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
