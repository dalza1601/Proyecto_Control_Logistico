using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto_Control_Logistico.Application.DTOs
{
    public class SaleDTO
    {
        [Required]
        [MaxLength(50)]
        public string NumberSale { get; set; } = string.Empty;

        public int ClientId { get; set; }

        public DateTime DateSale { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
    }
}
