using OfficeOpenXml;
using OfficeOpenXml.Style;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Interfaces;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Models;

namespace Proyecto_Control_Logistico.FL.UTIL.Excel.Services
{
    public class ExcelService : IExcelService
    {
        public async Task<byte[]> ExportToExcel<T>(IEnumerable<T> data, string sheetName, List<ExcelColumn<T>> columns)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Diego");
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add(sheetName);

            //Cabeceras
            for (int i = 0; i < columns.Count; i++)
            {
                worksheet.Cells[1, i + 1].Value = columns[i].Header;
                worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                worksheet.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            //Data 
            int row = 2;

            foreach (var item in data)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    worksheet.Cells[row, i + 1].Value = columns[i].ValueSelector(item);
                }
                row++;
            }

            //Style
            if (row > 2)
            {
                var range = worksheet.Cells[1, 1, row - 1, columns.Count];
                range.AutoFitColumns();
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            }

            return await package.GetAsByteArrayAsync();
        }

        public Task<List<T>> ImportFromExcel<T>(
    Stream excelStream,
    List<ExcelImportColumn<T>> columns) where T : new()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Diego");

            var result = new List<T>();

            using var package = new ExcelPackage(excelStream);

            var worksheet = package.Workbook.Worksheets.FirstOrDefault();

            if (worksheet == null || worksheet.Dimension == null)
                return Task.FromResult(result);

            var rowCount = worksheet.Dimension.Rows;
            var colCount = worksheet.Dimension.Columns;

            var headerMap = new Dictionary<string, int>();

            for (int col = 1; col <= colCount; col++)
            {
                var header = worksheet.Cells[1, col].Text.Trim();

                if (!string.IsNullOrWhiteSpace(header))
                {
                    headerMap[header] = col;
                }
            }

            for (int row = 2; row <= rowCount; row++)
            {
                var item = new T();

                foreach (var column in columns)
                {
                    if (!headerMap.ContainsKey(column.Header))
                        continue;

                    var colIndex = headerMap[column.Header];

                    var value = worksheet.Cells[row, colIndex].Value;

                    column.SetValue(item, value);
                }

                result.Add(item);
            }

            return Task.FromResult(result);
        }
    }
}
