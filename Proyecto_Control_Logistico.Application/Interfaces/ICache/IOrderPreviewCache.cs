using Proyecto_Control_Logistico.Application.DTOs;

namespace Proyecto_Control_Logistico.Application.Interfaces.ICache
{
    public interface IOrderPreviewCache
    {
        void Save(OrderDTO orderDto);
        OrderDTO? Get(bool keep = true);
        void Clear();
    }
}
