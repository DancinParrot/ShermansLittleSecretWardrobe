using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShermansLittleSecretWardrobe.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; } = String.Empty;

        // Set precision and scale, meaning price can only be $999.99 at max
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
    }
}
