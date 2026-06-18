using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty;
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceCost { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceSell { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public int Stock { get; set; }
        [Required]
        [MaxLength(50)]
        public string UnitMeasure { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
