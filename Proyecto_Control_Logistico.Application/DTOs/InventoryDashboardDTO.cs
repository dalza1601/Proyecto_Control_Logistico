namespace Proyecto_Control_Logistico.Application.DTOs
{
    public class InventoryDashboardDTO
    {
        public decimal TotalInputs { get; set; }
        public decimal TotalOutputs { get; set; }
        public decimal SalesBalance { get; set; }        // Entradas - Salidas (o ingreso por ventas)
        public int ActiveProducts { get; set; }
        public int ActiveWarehouses { get; set; }

        public List<string> Labels { get; set; }         // Ej: fechas para el eje X del grafico
        public List<decimal> SerieInputs { get; set; }  // Misma longitud que Labels
        public List<decimal> SerieOutputs { get; set; }   // Misma longitud que Labels

        public List<WarehouseDTO> WareHouses { get; set; }
        public List<MovementInventoryDTO> LastMovements { get; set; }
    }
}
