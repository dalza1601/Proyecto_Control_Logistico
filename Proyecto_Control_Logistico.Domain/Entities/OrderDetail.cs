using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
