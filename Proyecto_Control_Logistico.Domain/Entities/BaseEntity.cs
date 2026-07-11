namespace Proyecto_Control_Logistico.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime(2026, 6, 17);
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; } = true;
    }
}
