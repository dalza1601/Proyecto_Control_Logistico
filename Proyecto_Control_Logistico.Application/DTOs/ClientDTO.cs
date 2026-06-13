using System.ComponentModel.DataAnnotations;

namespace Proyecto_Control_Logistico.Application.DTOs
{
    public class ClientDTO
    {
        [Display(Name = "Número de documento")]
        [Required(ErrorMessage = "El número de documento es requerido.")]
        [MinLength(8, ErrorMessage = "El número de documento debe tener al menos 8 caracteres.")]
        public string Document { get; set; }
        
        [Display(Name = "Nombre completo")]
        [Required(ErrorMessage = "El nombre completo es requerido.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        public string FullName { get; set; }
        
        [Display(Name = "Celular")]
        public string Phone { get; set; }
        
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
