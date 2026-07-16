using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.UI.MVC.ViewModel
{
    public class DashboardViewModel
    {
        public IEnumerable<Product> ProductosBajoStock { get; set; } = new List<Product>();
        public IEnumerable<Product> Top10Productos { get; set; } = new List<Product>();
        public IEnumerable<Product> ProductosSinVender { get; set; } = new List<Product>();
        public List<string> MesesCompras { get; set; } = new List<string>();
        public List<decimal> TotalesCompras { get; set; } = new List<decimal>();
    }
}
