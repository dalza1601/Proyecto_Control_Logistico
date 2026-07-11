using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class MovementInventory: BaseEntity
    {
        public int ProductId { get; set; }
        public int WareHouseId { get; set; }
        public string MovementType { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastStock { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal StockAvailable { get; set; }
        public string Motive { get; set; } = string.Empty;

        public Product? Product { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
