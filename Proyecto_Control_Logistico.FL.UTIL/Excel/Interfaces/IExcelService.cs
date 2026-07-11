using OfficeOpenXml;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Models;

namespace Proyecto_Control_Logistico.FL.UTIL.Excel.Interfaces
{
    public interface IExcelService
    {
        Task<byte[]> ExportToExcel<T>(IEnumerable<T> data, string sheetName, List<ExcelColumn<T>> columns);
        Task<List<T>> ImportFromExcel<T>(Stream excelStream, List<ExcelImportColumn<T>> columns) where T : new();
    }
}
