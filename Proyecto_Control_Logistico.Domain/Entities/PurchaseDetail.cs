using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class PurchaseDetail : BaseEntity
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
