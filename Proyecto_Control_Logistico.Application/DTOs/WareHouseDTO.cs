using System.ComponentModel.DataAnnotations;

namespace Proyecto_Control_Logistico.Application.DTOs
{
    public class WareHouseDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La dirección es requerida")]
        [MaxLength(250, ErrorMessage = "La dirección no puede exceder los 250 caracteres")]
        public string Address { get; set; } = string.Empty;

        public int Inputs { get; set; }
        public int Outputs { get; set; }
    }
}
