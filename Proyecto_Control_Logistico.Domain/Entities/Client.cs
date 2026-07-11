using System.ComponentModel.DataAnnotations;

namespace Proyecto_Control_Logistico.Domain.Entities
{
    public class Client: BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Document { get; set; } = string.Empty;
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Active { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();

    }
}
