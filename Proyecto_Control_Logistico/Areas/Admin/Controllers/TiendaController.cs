using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.UI.MVC.Helpers;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TiendaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public TiendaController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager; 
        }

        public async Task<IActionResult> Index(string buscar)
        {
            // 1. Obtenemos todos los productos activos
            var productos = await _unitOfWork.ProductRepository.GetProductActivesAsync();

            // 2. Verificamos si el usuario escribió algo en el buscador
            if (!string.IsNullOrEmpty(buscar))
            {
                // Convertimos la búsqueda a minúsculas para evitar problemas de mayúsculas/minúsculas
                var busqueda = buscar.ToLower();

                // 3. Filtramos: Si el Nombre, Código o Descripción contiene la palabra buscada
                productos = productos.Where(p =>
                    p.Name.ToLower().Contains(busqueda) ||
                    p.Code.ToLower().Contains(busqueda) ||
                    p.Description.ToLower().Contains(busqueda)
                ).ToList();
            }

            // 4. Guardamos la palabra buscada en un ViewData para que la barra de texto 
            // no se borre después de recargar la página (buena experiencia de usuario)
            ViewData["FiltroActual"] = buscar;

            return View(productos);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarAlCarrito(int productoId)
        {
            // 1. Buscar el producto en la BD usando el repositorio genérico que ya vimos que existe
            var producto = await _unitOfWork.ProductRepository.GetByIdAsync(productoId);

            if (producto == null)
            {
                return NotFound();
            }

            // 2. Recuperar el carrito actual de la sesión (o crear uno nuevo si está vacío)
            var carrito = HttpContext.Session.GetObjectFromJson<List<CarritoItem>>("MiCarrito") ?? new List<CarritoItem>();

            // 3. Verificar si el producto ya está en el carrito
            var itemExistente = carrito.FirstOrDefault(c => c.ProductoId == productoId);

            if (itemExistente != null)
            {
                // Si ya existe, el criterio de aceptación dice: "aumentar la cantidad de cada uno"
                itemExistente.Cantidad++;
            }
            else
            {
                // Si es nuevo, lo agregamos a la lista
                carrito.Add(new CarritoItem
                {
                    ProductoId = producto.Id,
                    Nombre = producto.Name,
                    Precio = producto.PriceSell, // Usamos el precio de venta correcto
                    Cantidad = 1
                });
            }

            // 4. Guardar la lista actualizada de vuelta en la sesión
            HttpContext.Session.SetObjectAsJson("MiCarrito", carrito);

            // 5. Redirigir a la vista del carrito para simular la compra
            return RedirectToAction(nameof(VerCarrito));
        }

        public IActionResult VerCarrito()
        {
            // Recuperamos la lista de la sesión
            var carrito = HttpContext.Session.GetObjectFromJson<List<CarritoItem>>("MiCarrito") ?? new List<CarritoItem>();

            return View(carrito);
        }

        [Authorize]
        public async Task<IActionResult> SimularCompra()
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<CarritoItem>>("MiCarrito");
            if (carrito == null || !carrito.Any()) return RedirectToAction(nameof(Index));

            // Obtener el usuario firmado actual y su dirección
            var usuario = await _userManager.GetUserAsync(User);
            ViewData["DireccionCliente"] = usuario?.DireccionEntrega ?? "No registrada";

            HttpContext.Session.Remove("MiCarrito");
            return View(carrito);
        }
    }
}
