using System.ComponentModel.DataAnnotations;

namespace Proyecto_Control_Logistico.Application.DTOs
{
    public class MovementInventoryDTO
    {
        public string ProductName { get; set; }
        public string WareHouse { get; set; }
        public string MovementType { get; set; }     
        public decimal Quantity { get; set; }
        public string Motive { get; set; }
        public DateTime Date { get; set; }
    }
}
