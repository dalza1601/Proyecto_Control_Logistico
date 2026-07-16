using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.UI.MVC.ViewModel
{
    public class OrderViewModel
    {
        public List<OrderDTO> orders { get; set; }
        public OrderDTO ordersPreview { get; set; }
        public bool isPreviewView { get; set; }
    }
}
