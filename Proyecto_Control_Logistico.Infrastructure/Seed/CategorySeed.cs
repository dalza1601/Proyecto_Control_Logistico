using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Seed
{
    public static class CategorySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1,Name = "Bicicletas", Description = "Bicicletas y accesorios" },
                new Category { Id = 2,Name = "Componentes", Description = "Componentes de bicicletas" },
                new Category { Id = 3,Name = "Ropa", Description = "Ropa y accesorios" },
                new Category { Id = 4,Name = "Accesorios", Description = "Accesorios para bicicletas" },
                new Category { Id = 5,Name = "Libros", Description = "Materiales educativos y de referencia" },
                new Category { Id = 6, Name = "Comidas", Description = "Cualquier sustancia que pueda ser consumida" },
                new Category { Id = 7, Name = "Bebidas", Description = "Bebidas y líquidos" },
                new Category { Id = 8, Name = "Joyas", Description = "Accesorios de joyería" },
                new Category { Id = 9, Name = "Tecnología", Description = "Dispositivos electrónicos y accesorios" },
                new Category { Id = 10, Name = "Medicamentos", Description = "Medicamentos y tratamientos médicos" },
                new Category { Id = 11, Name = "Cosméticos", Description = "Productos de cuidado personal y belleza" },
                new Category { Id = 12, Name = "Jardinería", Description = "Plantas y suministros de jardinería" },
                new Category { Id = 13, Name = "Muebles", Description = "Muebles y decoración para el hogar" }
            );
        }
    }
}
