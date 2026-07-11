using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Interfaces;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.FL.UTIL.Excel.Services
{
    public class ProductImportService
    //public class ProductImportService : IProductImportService
    {
        //private readonly IProductRepository _repository;
        //private readonly ApplicationDbContext _context;

        //public ProductImportService(
        //    IProductRepository repository,
        //    ApplicationDbContext context)
        //{
        //    _repository = repository;
        //    _context = context;
        //}

        //public async Task ImportAsync(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        throw new Exception("Debe seleccionar un archivo.");

        //    ExcelPackage.License.SetNonCommercialPersonal("Tu Nombre");

        //    using var stream = new MemoryStream();

        //    await file.CopyToAsync(stream);

        //    using var package = new ExcelPackage(stream);

        //    var worksheet = package.Workbook.Worksheets.First();

        //    if (worksheet.Dimension == null)
        //        throw new Exception("El archivo está vacío.");

        //    int totalRows = worksheet.Dimension.Rows;

        //    const int batchSize = 1000;

        //    List<Product> products = new();

        //    _context.ChangeTracker.AutoDetectChangesEnabled = false;

        //    try
        //    {
        //        for (int row = 2; row <= totalRows; row++)
        //        {
        //            var name = worksheet.Cells[row, 1].Text.Trim();
        //            var code = worksheet.Cells[row, 2].Text.Trim();

        //            decimal.TryParse(
        //                worksheet.Cells[row, 2].Text,
        //                out decimal price);

        //            Product product = new Product
        //            {
        //                Code = code,
        //                Name = name
                        
        //            };

        //            products.Add(product);

        //            if (products.Count >= batchSize)
        //            {
        //                await SaveBatch(products);
        //            }
        //        }

        //        if (products.Count > 0)
        //        {
        //            await SaveBatch(products);
        //        }
        //    }
        //    finally
        //    {
        //        _context.ChangeTracker.AutoDetectChangesEnabled = true;
        //    }
        //}

        //private async Task SaveBatch(List<Product> products)
        //{
        //    await _repository.AddRangeAsync(products);

        //    await _repository.SaveAsync();

        //    _context.ChangeTracker.Clear();

        //    products.Clear();
        //}
    }
}
