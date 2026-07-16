using OfficeOpenXml;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Domain.Constant;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Interfaces.IReadExcel;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Models;

namespace Proyecto_Control_Logistico.FL.UTIL.Excel.Services.ReadExcel
{
    public class OrderReadExcel : IOrderReadExcel
    {
        public Task<byte[]> ExportToExcel<T>(IEnumerable<T> data, string sheetName, List<ExcelColumn<T>> columns)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ImportFromExcel<T>(Stream excelStream, List<ExcelImportColumn<T>> columns) where T : new()
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDTO> ImportOrderFromExcel(Stream excelStream)
        {
            ExcelPackage.License.SetNonCommercialPersonal(ExcelConstants.NON_COMMERCIAL_PERSONAL);
            OrderDTO result = new OrderDTO();
            using var package = new ExcelPackage(excelStream);

            // Seleccionamos la 1ra pestaña del archivo Excel
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();

            if (worksheet == null || worksheet.Dimension == null)
            {
                throw new Exception(ExcelConstants.NO_SHEET_FOUND);
            }

            // Obtenemos los valores de las celdas específicas
            result.NumberOrder = worksheet.Cells[1, 2].Text; // Número de orden en la celda B1
            result.SupplierId = int.Parse(worksheet.Cells[3, 2].Text); // ID del proveedor en la celda B3
            result.SupplierName = worksheet.Cells[2, 2].Text; // Nombre del proveedor en la celda B2
            result.Status = StatusConstants.PENDING_CODE;
            result.DateOrder = DateTime.Now;

            // Obtenemos los detalles de la orden a partir de la fila 8
            int row = 8;
            int maxRow = worksheet.Dimension.End.Row;

            if (maxRow < 8)
            {
                throw new Exception(ExcelConstants.NO_ROWS_FOUND);
            }

            // Declaramos la lista de detalles de la orden
            List<OrderDetailDTO> orderDetails = new List<OrderDetailDTO>();

            for(int i = row; i <= maxRow; i++)
            {
                orderDetails.Add(new OrderDetailDTO
                {
                    ProductName = worksheet.Cells[i, 2].Text, // Nombre del producto en la columna B
                    ProductId = int.Parse(worksheet.Cells[i, 3].Text), // ID del producto en la columna C
                    ProductCode = worksheet.Cells[i, 4].Text, // Código del producto en la columna D
                    Quantity = decimal.Parse(worksheet.Cells[i, 5].Text), // Cantidad en la columna E
                    UnitPrice = decimal.Parse(worksheet.Cells[i, 6].Text), // Precio unitario en la columna F
                    TotalPrice = decimal.Parse(worksheet.Cells[i, 7].Text) // Precio total en la columna G
                });
            }

            result.TotalAmount = orderDetails.Sum(od => od.TotalPrice);
            result.OrderDetails = orderDetails;

            return result;
        }
    }
}
