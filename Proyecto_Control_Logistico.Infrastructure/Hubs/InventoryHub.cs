using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Proyecto_Control_Logistico.Infrastructure.Hubs
{
    public class InventoryHub : Hub
    {
        private readonly ILogger<InventoryHub> _logger;

        public InventoryHub(ILogger<InventoryHub> logger)
        {
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation("Cliente conectado: {ConnectionId}", Context.ConnectionId);
            await Clients.Caller.SendAsync("ReceiveMessage", "Conectado al servidor");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _logger.LogInformation("Cliente desconectado: {ConnectionId}", Context.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
