using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;

namespace Proyecto_Control_Logistico.Application.UseCase.InventoryDashboard.Queries
{
    public class GetInventoryDashboardQuery
    {
        private readonly IMovementInventoryRepository _movementInventoryRepository;
        private readonly IWareHouseRepository _warehouseRepository;
        private readonly IProductRepository _productRepository;

        public GetInventoryDashboardQuery(IMovementInventoryRepository movementInventoryRepository,
            IWareHouseRepository warehouseRepository, IProductRepository productRepository)
        {
            _movementInventoryRepository = movementInventoryRepository;
            _warehouseRepository = warehouseRepository;
            _productRepository = productRepository;
        }

        public async Task<InventoryDashboardDTO> ExecuteAsync()
        {
            var movementInventoryLastMovements = await _movementInventoryRepository.GetLastMovementsAsync();
            var warehouseSummary = await _warehouseRepository.GetWareHouseSummaryAsync();
            int totalActiveProducts = await _productRepository.ActiveProductsCountAsync();
            int totalInputs = warehouseSummary.Sum(w => w.Inputs);
            int totalOutputs = warehouseSummary.Sum(w => w.Outputs);

            return new InventoryDashboardDTO
            {
                TotalInputs = totalInputs,
                TotalOutputs = totalOutputs,
                SalesBalance = 0,
                ActiveProducts = totalActiveProducts,
                ActiveWarehouses = warehouseSummary.Count,
                Labels = warehouseSummary.Select(w => w.Name).ToList(),
                SerieInputs = warehouseSummary.Select(w => w.Inputs).ToList(),
                SerieOutputs = warehouseSummary.Select(w => w.Outputs).ToList(),
                Warehouses = warehouseSummary,
                LastMovements = movementInventoryLastMovements.ToList()
            };
        }
    }
}
