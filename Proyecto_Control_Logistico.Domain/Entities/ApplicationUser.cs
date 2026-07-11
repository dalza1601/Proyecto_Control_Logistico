using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class ApplicationUser: IdentityUser
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string FullName { get; set; }
        public string? DireccionEntrega { get; set; }
    }
}
