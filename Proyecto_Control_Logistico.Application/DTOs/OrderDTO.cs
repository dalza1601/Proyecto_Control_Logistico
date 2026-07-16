namespace Proyecto_Control_Logistico.Application.DTOs
{
    public class OrderDTO
    {
        public string NumberOrder { get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime DateOrder { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
