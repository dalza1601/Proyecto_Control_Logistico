namespace Proyecto_Control_Logistico.Application.DTOs
{
    public class OrderDetailDTO
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
