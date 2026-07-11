
using Proyecto_Control_Logistico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository
{
    public interface IPurchaseRepository
    {
        Task SaveAsync(Purchase model);
    }
}
