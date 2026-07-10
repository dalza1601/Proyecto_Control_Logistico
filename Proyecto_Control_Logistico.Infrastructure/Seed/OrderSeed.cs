using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Seed
{
    public static class OrderSeed
    {
        public static List<Order> Get()
        {
            return new List<Order>
            {
                new Order { Id = 1, NumberOrder = "ORD-000000001", SupplierId = 1, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 5470.00m },
                new Order { Id = 2, NumberOrder = "ORD-000000002", SupplierId = 2, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 11330.00m },
                new Order { Id = 3, NumberOrder = "ORD-000000003", SupplierId = 3, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 20465.00m },
                new Order { Id = 4, NumberOrder = "ORD-000000004", SupplierId = 4, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 11060.00m },
                new Order { Id = 5, NumberOrder = "ORD-000000005", SupplierId = 5, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 7970.00m },
                new Order { Id = 6, NumberOrder = "ORD-000000006", SupplierId = 6, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 16475.00m },
                new Order { Id = 7, NumberOrder = "ORD-000000007", SupplierId = 7, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 21170.00m },
                new Order { Id = 8, NumberOrder = "ORD-000000008", SupplierId = 8, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 11060.00m },
                new Order { Id = 9, NumberOrder = "ORD-000000009", SupplierId = 9, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 11285.00m },
                new Order { Id = 10, NumberOrder = "ORD-000000010", SupplierId = 10, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 18070.00m },
                new Order { Id = 11, NumberOrder = "ORD-000000011", SupplierId = 1, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 25190.00m },
                new Order { Id = 12, NumberOrder = "ORD-000000012", SupplierId = 2, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 15335.00m },
                new Order { Id = 13, NumberOrder = "ORD-000000013", SupplierId = 3, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 13370.00m },
                new Order { Id = 14, NumberOrder = "ORD-000000014", SupplierId = 4, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 20930.00m },
                new Order { Id = 15, NumberOrder = "ORD-000000015", SupplierId = 5, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 33215.00m },
                new Order { Id = 16, NumberOrder = "ORD-000000016", SupplierId = 6, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 14900.00m },
                new Order { Id = 17, NumberOrder = "ORD-000000017", SupplierId = 7, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 15470.00m },
                new Order { Id = 18, NumberOrder = "ORD-000000018", SupplierId = 8, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 27125.00m },
                new Order { Id = 19, NumberOrder = "ORD-000000019", SupplierId = 9, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 37870.00m },
                new Order { Id = 20, NumberOrder = "ORD-000000020", SupplierId = 10, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 8810.00m },
                new Order { Id = 21, NumberOrder = "ORD-000000021", SupplierId = 1, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 19835.00m },
                new Order { Id = 22, NumberOrder = "ORD-000000022", SupplierId = 2, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 31970.00m },
                new Order { Id = 23, NumberOrder = "ORD-000000023", SupplierId = 3, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 39290.00m },
                new Order { Id = 24, NumberOrder = "ORD-000000024", SupplierId = 4, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 11345.00m },
                new Order { Id = 25, NumberOrder = "ORD-000000025", SupplierId = 5, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 24470.00m },
                new Order { Id = 26, NumberOrder = "ORD-000000026", SupplierId = 6, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 32930.00m },
                new Order { Id = 27, NumberOrder = "ORD-000000027", SupplierId = 7, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 32165.00m },
                new Order { Id = 28, NumberOrder = "ORD-000000028", SupplierId = 8, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 15370.00m },
                new Order { Id = 29, NumberOrder = "ORD-000000029", SupplierId = 9, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 25370.00m },
                new Order { Id = 30, NumberOrder = "ORD-000000030", SupplierId = 10, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 40175.00m },
                new Order { Id = 31, NumberOrder = "ORD-000000031", SupplierId = 1, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 29960.00m },
                new Order { Id = 32, NumberOrder = "ORD-000000032", SupplierId = 2, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 16610.00m },
                new Order { Id = 33, NumberOrder = "ORD-000000033", SupplierId = 3, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 30785.00m },
                new Order { Id = 34, NumberOrder = "ORD-000000034", SupplierId = 4, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 49070.00m },
                new Order { Id = 35, NumberOrder = "ORD-000000035", SupplierId = 5, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 22400.00m },
                new Order { Id = 36, NumberOrder = "ORD-000000036", SupplierId = 6, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 20195.00m },
                new Order { Id = 37, NumberOrder = "ORD-000000037", SupplierId = 7, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 38770.00m },
                new Order { Id = 38, NumberOrder = "ORD-000000038", SupplierId = 8, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 47330.00m },
                new Order { Id = 39, NumberOrder = "ORD-000000039", SupplierId = 9, DateOrder = new DateTime(2026, 6, 17), TotalAmount = 26945.00m }
            };
        }
    }
}
