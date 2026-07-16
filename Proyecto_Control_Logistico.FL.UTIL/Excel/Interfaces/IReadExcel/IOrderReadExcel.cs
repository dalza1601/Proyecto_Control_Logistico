using Proyecto_Control_Logistico.Application.DTOs;

namespace Proyecto_Control_Logistico.FL.UTIL.Excel.Interfaces.IReadExcel
{
    public interface IOrderReadExcel : IExcelService
    {
        Task<OrderDTO> ImportOrderFromExcel(Stream excelStream);
    }
}
