using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Seed;

namespace Proyecto_Control_Logistico.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        //Add DBSets
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Inventary> Inventaries { get; set; }
        public DbSet<MovementInventory> MovementInventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Category
            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(c => c.Id);

                e.HasMany (c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);// Restringir eliminación en cascada
            });
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(c => c.Id);

                e.HasIndex(p => p.Code).IsUnique();
            });
            modelBuilder.Entity<Supplier>(e =>
            {
                e.HasKey(c => c.Id);
                e.HasIndex(s => s.RUC).IsUnique();
            });
            modelBuilder.Entity<Client>(e =>
            {
                e.HasKey(c => c.Id);
            });
            modelBuilder.Entity<Warehouse>(e =>
            {
                e.HasKey(c => c.Id);
                e.HasMany(x => x.Inventories)
                .WithOne(x => x.Warehouse)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
            });
             modelBuilder.Entity<Inventary>(e =>
            {
                e.HasKey(c => c.Id);

                e.HasOne(x => x.Product)
                .WithMany(x => x.Inventories)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Warehouse)
                .WithMany(x => x.Inventories)
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasIndex(x => new {x.ProductId, x.WarehouseId}).IsUnique();
            });
            modelBuilder.Entity<MovementInventory>(e =>
           {
               e.HasKey(c => c.Id);

               e.HasOne(x => x.Product)
               .WithMany()
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
           });
            modelBuilder.Entity<Order>(e =>
            {
                e.HasKey(c => c.Id);

                e.HasOne(x => x.Supplier)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(x => x.OrderDetails)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasIndex(x => x.NumberOrder).IsUnique();
            });
            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.HasKey(c => c.Id);

                e.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Sale>(e =>
            {
                e.HasKey(c => c.Id);

                e.HasOne(x => x.Client)
                .WithMany( x => x.Sales)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasIndex(x => x.NumberSale).IsUnique();
            
            });
            modelBuilder.Entity<SaleDetail>(e =>
            {
                e.HasKey(c => c.Id);

                e.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
