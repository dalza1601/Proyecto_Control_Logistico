using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class CarritoItem
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? ImagenUrl { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal => Precio * Cantidad;
    }
}
