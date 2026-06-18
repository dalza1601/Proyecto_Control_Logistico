using Proyecto_Control_Logistico.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Control_Logistico.Infrastructure.Mongo.Documents
{
    public class CategoryDocument: MongoDocument
    {
        public string name { get; set; }
        [Required]
        [MaxLength(250)]
        public string description { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public CategoryDocument()
        { }

        public CategoryDocument(string name, string? description)
        {
            name = name;
            description = description;
        }

        public void Update(string name, string? description)
        {
            name = name;
            description = description;
        }
    }
}
