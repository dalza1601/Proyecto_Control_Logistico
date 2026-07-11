using System.ComponentModel.DataAnnotations;
using Proyecto_Control_Logistico.Domain;

namespace Proyecto_Control_Logistico.Application.DTOs

{
    public class SaleDTO
    {
        public int Id { get; set; }

        [Display(Name = "Número de venta")]
        public string NumberSale { get; set; } = string.Empty;

        [Display(Name = "Cliente")]
        public int ClientId { get; set; }

        [Display(Name = "Cliente")]
        public string ClientName { get; set; } = string.Empty;

        [Display(Name = "Fecha de venta")]
        public DateTime DateSale { get; set; }

        [Display(Name = "Total")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Estado")]
        public string Status { get; set; } = Constants.SALE_STATUS_REGISTERED;

        public List<SaleDetailDTO> Details { get; set; } = new();

    }
}