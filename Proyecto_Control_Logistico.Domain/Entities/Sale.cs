using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    [Index(nameof(NumberSale), IsUnique = true)]
    public class Sale : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string NumberSale { get; set; } = string.Empty;
        public int ClientId { get; set; }
        public DateTime DateSale { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        public Client? Client { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}
