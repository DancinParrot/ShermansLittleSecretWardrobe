using System.ComponentModel.DataAnnotations;

namespace ShermansLittleSecretWardrobe.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = String.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
