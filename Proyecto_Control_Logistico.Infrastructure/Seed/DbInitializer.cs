using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Infrastructure.Data;

namespace Proyecto_Control_Logistico.Infrastructure.Seed
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Para aplicar migraciones pendientes y crear la base de datos si no existe
            context.Database.Migrate();

            SeedWithIdentityInsert(context, context.Categories, CategorySeed.Get());
            SeedWithIdentityInsert(context, context.Products, ProductSeed.Get());
            SeedWithIdentityInsert(context, context.Suppliers, SupplierSeed.Get());
            SeedWithIdentityInsert(context, context.Warehouses, WareHouseSeed.Get());
            SeedWithIdentityInsert(context, context.Inventaries, InventorySeed.Get());
            SeedWithIdentityInsert(context, context.MovementInventories, MovementInventorySeed.Get());
            SeedWithIdentityInsert(context, context.Orders, OrderSeed.Get());
            SeedWithIdentityInsert(context, context.OrderDetails, OrderDetailSeed.Get());
        }

        // Funcion para sembrar datos con Identity Insert habilitado, es Generico para cualquier
        // entidad T, y evita duplicados si ya hay datos en la tabla
        private static void SeedWithIdentityInsert<T>(ApplicationDbContext context, DbSet<T> dbSet, List<T> data)
            where T : class
        {
            // Si los datos ya existen, no hacer nada
            if (dbSet.Any()) return;

            // Obtener el nombre de la tabla correspondiente a la entidad T
            var tableName = context.Model.FindEntityType(typeof(T))!.GetTableName();

            // Abrir la conexión a la base de datos y habilitar Identity Insert
            context.Database.OpenConnection();

            try
            {
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}] ON");
                dbSet.AddRange(data);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}] OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }
    }
}
