using Proyecto_Control_Logistico.Application.Interfaces.IHub;
using Proyecto_Control_Logistico.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Proyecto_Control_Logistico.Infrastructure.Services.Inventory
{
    public class InventoryNotifier : IInventoryNotifier
    {
        private readonly IHubContext<InventoryHub> _hub;

        public InventoryNotifier(IHubContext<InventoryHub> hub)
        {
            _hub = hub;
        }

        public Task NotifyInventoryDashboardUpdateAsync()
        {
            return _hub.Clients.All.SendAsync("DashboardUpdated");
        }
    }
}
