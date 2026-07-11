using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.FL.UTIL.Excel.Models
{
    public class ExcelColumn<T>
    {
        public string Header { get; set; } = string.Empty;
        public Func<T, object?> ValueSelector { get; set; } = default!;
    }
}
