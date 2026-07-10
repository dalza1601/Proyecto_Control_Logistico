using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Seed
{
    public static class SupplierSeed
    {
        public static List<Supplier> Get()
        {
            return new List<Supplier>
            {
                new Supplier { Id=1, RUC = "20100004756", Name = "Monark Perú S.A.", Address = "Av. Centenario 318, Huancayo", Phone = "987654321", Email = "ventas@monark.pe" },
                new Supplier { Id=2, RUC = "20100000002", Name = "Ingram Micro Perú S.A.", Address = "Av. El Derby 250, Santiago de Surco", Phone = "986123456", Email = "contacto@ingrammicro.pe" },
                new Supplier { Id=3, RUC = "20100000003", Name = "Deltron S.A.", Address = "Av. Argentina 3120, Cercado de Lima", Phone = "985456789", Email = "ventas@deltron.com.pe" },
                new Supplier { Id=4, RUC = "20100000004", Name = "Industrias Nettalco S.A.", Address = "Av. Nicolás Arriola 780, Lima", Phone = "984567890", Email = "comercial@nettalco.pe" },
                new Supplier { Id=5, RUC = "20100030676", Name = "Distribuidora Navarrete S.A.", Address = "Av. Carretera Central, Lima", Phone = "983678901", Email = "ventas@navarrete.pe" },
                new Supplier { Id=6, RUC = "20346289636", Name = "Distribuidora de Alimentos Lozano S.A.", Address = "Av. Nicolás Ayllón 2341, El Agustino, Lima", Phone = "982789012", Email = "empresas@lozano.pe" },
                new Supplier { Id=7, RUC = "10471159102", Name = "Sixsa Perú Joyas E.I.R.L.", Address = "Av. República de Panamá 3535, San Isidro", Phone = "981890123", Email = "corporativo@sixsa.pe" },
                new Supplier { Id=8, RUC = "20536390201", Name = "Jobal Pharma E.I.R.L.", Address = "Av. Del Pinar 180, Santiago de Surco", Phone = "980901234", Email = "ventas@jobal.pe" },
                new Supplier { Id=9, RUC = "20611866616", Name = "NewSeoul S.A.C.", Address = "Av. Benavides 1555, Miraflores", Phone = "989012345", Email = "contacto@newseoul.pe" },
                new Supplier { Id=10, RUC = "20508514434", Name = "Mundo Muebles S.A.C.", Address = "Av. Primavera 1050, Santiago de Surco", Phone = "988123456", Email = "ventas@mundomuebles.pe" }
            };
        }
    }
}
