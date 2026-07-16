using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_Control_Logistico.Domain;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class Sale : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string NumberSale { get; set; } = string.Empty;
        public int ClientId { get; set; }
        public DateTime DateSale { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        [Required]
        [MaxLength(30)]
        public string Status { get; set; } = Constants.SALE_STATUS_REGISTERED;
        public Client? Client { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}
