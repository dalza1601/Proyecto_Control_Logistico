using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string NumberOrder{ get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public DateTime DateOrder { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        public Supplier? Supplier { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    }
}
