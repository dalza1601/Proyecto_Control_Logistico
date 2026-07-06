using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Seed
{
    public static class WareHouseSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse { Id = 1, Name = "Almacén Central", Address = "Calle Linos 231" },
                new Warehouse { Id = 2, Name = "Almacén Norte", Address = "Avenida Austin 561" },
                new Warehouse { Id = 3, Name = "Almacén Sur", Address = "Calle Surita 389" },
                new Warehouse { Id = 4, Name = "Almacén Este", Address = "Avenida Nublar 593" },
                new Warehouse { Id = 5, Name = "Almacén Oeste", Address = "Calle Orestes 1963" }
            );
        }
    }
}
