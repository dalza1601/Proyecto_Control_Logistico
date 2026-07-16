using Proyecto_Control_Logistico.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllAsync();
    }

}
