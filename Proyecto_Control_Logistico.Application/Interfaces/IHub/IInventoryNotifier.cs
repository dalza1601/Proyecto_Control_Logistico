namespace Proyecto_Control_Logistico.Application.Interfaces.IHub
{
    public interface IInventoryNotifier
    {
        Task NotifyInventoryDashboardUpdateAsync();
    }
}
