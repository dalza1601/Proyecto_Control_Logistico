using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.FL.UTIL.Excel.Interfaces
{
    public interface IProductImportService
    {
        Task ImportAsync(IFormFile file);
    }
}
