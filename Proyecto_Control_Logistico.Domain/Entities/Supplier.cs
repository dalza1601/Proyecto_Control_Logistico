using System.ComponentModel.DataAnnotations;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class Supplier: BaseEntity
    {
        [Required]
        [MaxLength(11, ErrorMessage = "El RUC debe tener un máximo de 11 caracteres")]
        public string RUC { get; set; } = string.Empty;
        [Required]
        [MaxLength(150, ErrorMessage = "La Razon Social debe tener un máximo de 150 caracteres")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(250, ErrorMessage = "La Dirección debe tener un máximo de 250 caracteres")]
        public string Address { get; set; } = string.Empty;
        [Required]
        [MaxLength(20, ErrorMessage = "El Teléfono debe tener un máximo de 20 caracteres")]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "El Correo Electrónico debe tener un máximo de 100 caracteres")]
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
