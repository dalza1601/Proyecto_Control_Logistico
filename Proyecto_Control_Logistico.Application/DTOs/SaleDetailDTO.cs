using System.ComponentModel.DataAnnotations;

namespace Proyecto_Control_Logistico.Application.DTOs
{
    public class SaleDetailDTO
    {
        public int Id { get; set; }

        public int SaleId { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "Producto")]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "Cantidad")]
        public decimal Quantity { get; set; }

        [Display(Name = "Precio unitario")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Subtotal")]
        public decimal TotalPrice { get; set; }
    }
}
