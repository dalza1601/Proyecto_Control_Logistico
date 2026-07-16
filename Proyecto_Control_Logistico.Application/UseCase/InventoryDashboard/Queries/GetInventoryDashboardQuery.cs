using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Domain.Constant;

namespace Proyecto_Control_Logistico.Application.UseCase.InventoryDashboard.Queries
{
    public class GetInventoryDashboardQuery
    {
        private readonly IMovementInventoryRepository _movementInventoryRepository;
        private readonly IProductRepository _productRepository;

        public GetInventoryDashboardQuery(IMovementInventoryRepository movementInventoryRepository,
            IProductRepository productRepository)
        {
            _movementInventoryRepository = movementInventoryRepository;
            _productRepository = productRepository;

        }

        public async Task<InventoryDashboardDTO> ExecuteAsync()
        {
            var movementInventoryLastMovements = await _movementInventoryRepository.GetLastMovementsAsync();
            var movementInventoryWithWareHouse = await _movementInventoryRepository.GetMovementWithWareHouseAsync();
            int totalActiveProducts = await _productRepository.ActiveProductsCountAsync();

            var warehouseSummary = movementInventoryWithWareHouse.GroupBy(m => m.Warehouse)
                .Select(g => new WareHouseDTO
                {
                    Name = g.Key.Name,
                    Inputs = (int)g.Where(x => x.MovementType == MovementInventoryConstants.MOVEMENT_TYPE_INPUT).Sum(x => x.Quantity),
                    Outputs = (int)g.Where(x => x.MovementType == MovementInventoryConstants.MOVEMENT_TYPE_OUTPUT).Sum(x => x.Quantity)
                })
                .ToList();

            int totalInputs = warehouseSummary.Sum(w => w.Inputs);
            int totalOutputs = warehouseSummary.Sum(w => w.Outputs);

            var lastMovements = movementInventoryLastMovements.Select(m => new MovementInventoryDTO
            {
                ProductName = m.Product.Name,
                WareHouseName = m.Warehouse.Name,
                MovementType = m.MovementType,
                Quantity = m.Quantity,
                Motive = m.Motive,
                Date = m.CreatedAt
            }).ToList();

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
                LastMovements = lastMovements
            };
        }
    }
}
