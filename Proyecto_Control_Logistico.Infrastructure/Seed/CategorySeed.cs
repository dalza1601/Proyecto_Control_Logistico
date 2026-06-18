using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Seed
{
    public static class CategorySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id=1,Name = "Bikes", Description = "Bicycles and related equipment" },
                new Category {Id=2,Name = "Components", Description = "Bike components and parts" },
                new Category {Id=3,Name = "Clothing", Description = "Apparel and accessories" },
                new Category {Id=4,Name = "Accessories", Description = "Bike accessories and gear" },
                new Category {Id=5,Name = "Books", Description = "Educational and reference materials" }
            );
        }
    }
}
