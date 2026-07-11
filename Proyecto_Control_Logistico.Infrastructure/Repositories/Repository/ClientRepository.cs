using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Client?> GetByDniAsync(string dni)
        {
            return await _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Document == dni);
        }

        public async Task<bool> ClientExistAsync(string dni)
        {
            return await _context.Clients
                .AnyAsync(x => x.Document == dni);
        }
    }
}
