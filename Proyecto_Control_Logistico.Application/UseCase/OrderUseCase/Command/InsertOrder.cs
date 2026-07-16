using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Application.UseCase.OrderUseCase.Command
{
    public class InsertOrder
    {
        private readonly IOrderRepository _orderRepository;

        public InsertOrder(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> ExecuteAsync(OrderDTO orderDto)
        {
            Order order = new Order
            {
                NumberOrder = orderDto.NumberOrder,
                SupplierId = orderDto.SupplierId,
                Status = orderDto.Status,
                DateOrder = DateTime.Now,
                CreatedAt = DateTime.Now,
                Active = true,
                OrderDetails = orderDto.OrderDetails.Select(od => new OrderDetail
                {
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice,
                    TotalPrice = od.TotalPrice,
                    CreatedAt = DateTime.Now,
                    Active = true
                }).ToList()
            };
            var result = await _orderRepository.SaveOrderAsync(order);
            return result;
        }
    }
}
