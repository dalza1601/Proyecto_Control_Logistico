using Proyecto_Control_Logistico.Application.DTOs;

namespace Proyecto_Control_Logistico.Application.UseCase.Warehouse.Queries
{
    public class GetWarehouseSummaryQuery
    {
        public async Task<List<WarehouseDTO>> ExecuteAsync(IWareHouseRepository warehouseRepository)
        {
            var warehouses = await warehouseRepository.GetAllAsync();
            var warehouseSummaries = warehouses.Select(w => new WarehouseDTO
            {
                Name = w.Name,
                Inputs = w.Movements.Count(m => m.MovementType == "Input"),
                Outputs = w.Movements.Count(m => m.MovementType == "Output")
            }).ToList();
            return warehouseSummaries;
        }
    }
}
