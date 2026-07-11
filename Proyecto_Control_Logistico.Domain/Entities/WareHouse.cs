using System.ComponentModel.DataAnnotations;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class Warehouse: BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;
        public ICollection<Inventary> Inventories { get; set; } = new List<Inventary>();
    }
}
