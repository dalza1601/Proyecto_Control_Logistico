using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.FL.UTIL.Excel.Models
{
    public class ExcelImportColumn<T>
    {
        public string Header { get; set; } = string.Empty;
        public Action<T, object?> SetValue { get; set; } = default!;
    }
}
