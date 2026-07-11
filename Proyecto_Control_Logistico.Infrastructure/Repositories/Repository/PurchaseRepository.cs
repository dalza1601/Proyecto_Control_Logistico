using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public PurchaseRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task SaveAsync(Purchase purchase)
        {
            var order = new Order
            {
                NumberOrder = purchase.NumberOrder,
                SupplierId = purchase.SupplierId,
                DateOrder = purchase.DateOrder,
                TotalAmount = purchase.Details.Sum(x => x.Quantity * x.UnitPrice),
                Active = true,
                CreatedAt = DateTime.Now
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in purchase.Details)
            {
                await _context.OrderDetails.AddAsync(new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.Quantity * item.UnitPrice,
                    Active = true,
                    CreatedAt = DateTime.Now
                });
            }

            await _unitOfWork.SaveAsync();
        }
    }
}
