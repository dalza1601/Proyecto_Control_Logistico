using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class Inventary : BaseEntity
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal StockAvailable { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }

        public Product? Product { get; set; }
        public Warehouse? Warehouse { get; set; }
       
    }
}
