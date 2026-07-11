using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class Purchase
    {
        public string NumberOrder { get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public DateTime DateOrder { get; set; }

        public List<PurchaseDetail> Details { get; set; } = new();
    }
}
