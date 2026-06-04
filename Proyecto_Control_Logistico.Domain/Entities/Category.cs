using System.ComponentModel.DataAnnotations;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
} 
