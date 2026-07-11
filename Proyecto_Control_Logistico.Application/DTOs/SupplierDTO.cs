using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Control_Logistico.Application.DTOs
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        [Display(Name = "RUC")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El RUC debe tener exactamente 11 dígitos.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El RUC solo debe contener números.")]
        public string RUC { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(150, ErrorMessage = "El nombre no puede exceder 150 caracteres")]
        public string Name { get; set; }
        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "La Direccion es requerido")]
        [MaxLength(250, ErrorMessage = "El nombre no puede exceder 250 caracteres")]
        public string Address { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
        public string Phone { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El Correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido.")]
        [MaxLength(100, ErrorMessage = "El teléfono no puede exceder 100 caracteres")]
        public string Email { get; set; }
    }
}
