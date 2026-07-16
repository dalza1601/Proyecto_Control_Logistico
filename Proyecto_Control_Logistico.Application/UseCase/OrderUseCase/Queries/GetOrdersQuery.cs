using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Domain.Maps;

namespace Proyecto_Control_Logistico.Application.UseCase.OrderUseCase.Queries
{
    public class GetOrdersQuery
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISupplierRepository _supplierRepository;
        public GetOrdersQuery(IOrderRepository orderRepository, ISupplierRepository supplierRepository)
        {
            _orderRepository = orderRepository;
            _supplierRepository = supplierRepository;
        }
        public async Task<List<OrderDTO>> ExecuteAsync()
        {
            var orders = await _orderRepository.GetLastOrdersAsync();
            
            StatusMap statusMap = new StatusMap();

            var orderDTOs = orders.ToList().Select(order => new OrderDTO
            {
                NumberOrder = order.NumberOrder,
                SupplierId = order.SupplierId,
                SupplierName = order.Supplier.Name,
                TotalAmount = order.TotalAmount,
                Status = statusMap.ObtenerDescripcion(order.Status),
                DateOrder = order.DateOrder
            }).ToList();
            return orderDTOs;
        }
    }
}
