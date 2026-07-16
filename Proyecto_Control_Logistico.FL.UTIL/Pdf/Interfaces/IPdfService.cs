using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.FL.UTIL.Pdf.Interfaces
{
    public interface IPdfService
    {
        byte[] GenerateSaleReceipt(Sale sale);
    }
}