using System.ComponentModel.DataAnnotations;

namespace Proyecto_Control_Logistico.Application.DTOs
{
    public class CategoryDTO
    {

        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(150, ErrorMessage = "El nombre no puede exceder 150 caracteres")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción es requerida")]
        [MaxLength(250, ErrorMessage = "La descripción no puede exceder 250  caracteres")]
        public string Description { get; set; } = string.Empty;
    }
}
