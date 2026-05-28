using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class WareHouse: BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;
        public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    }
}
