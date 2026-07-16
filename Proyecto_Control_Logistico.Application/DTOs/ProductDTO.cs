using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Control_Logistico.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "El Codigo es requerido")]
        [MaxLength(50, ErrorMessage = "El codigo no puede exceder 50 caracteres")]
        public string Code { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(150, ErrorMessage = "El nombre no puede exceder 150 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "La Descripcion es requerido")]
        [MaxLength(300, ErrorMessage = "El nombre no puede exceder 300 caracteres")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Precio Costo")]
        [Required(ErrorMessage = "El Precio Costo es requerido")]
        [Range(0, double.MaxValue)]
        public decimal PriceCost { get; set; }


        [Display(Name = "Precio Venta")]
        [Required(ErrorMessage = "El Precio Venta es requerido")]
        [Range(0, double.MaxValue)]
        public decimal PriceSell { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "El Stock requerido")]
        [Range(0, double.MaxValue)]
        public int Stock { get; set; }

        [Display(Name = "Unidad")]
        [Required(ErrorMessage = "La Unidad requerido")]
        public string UnitMeasure { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;
    }
}
