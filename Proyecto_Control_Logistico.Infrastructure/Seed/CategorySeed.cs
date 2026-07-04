using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Seed
{
    public static class CategorySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1,Name = "Bikes", Description = "Bicycles and related equipment" },
                new Category { Id = 2,Name = "Components", Description = "Bike components and parts" },
                new Category { Id = 3,Name = "Clothing", Description = "Apparel and accessories" },
                new Category { Id = 4,Name = "Accessories", Description = "Bike accessories and gear" },
                new Category { Id = 5,Name = "Books", Description = "Educational and reference materials" },
                new Category { Id = 6, Name = "Foods", Description = "Any substance that can be consumed" },
                new Category { Id = 7, Name = "Drinks", Description = "Beverages and liquids" },
                new Category { Id = 8, Name = "Jewelry", Description = "Decorative items and accessories" },
                new Category { Id = 9, Name = "Technology", Description = "Electronic devices and gadgets" },
                new Category { Id = 10, Name = "Medicaments", Description = "Medical drugs and treatments" },
                new Category { Id = 11, Name = "Cosmetics", Description = "Personal care and beauty products" },
                new Category { Id = 12, Name = "Garden", Description = "Plants and gardening supplies" },
                new Category { Id = 13, Name = "Furniture", Description = "Furniture and home decor" }
            );
        }
    }
}
