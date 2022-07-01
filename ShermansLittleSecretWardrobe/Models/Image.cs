using System.ComponentModel.DataAnnotations.Schema;

namespace ShermansLittleSecretWardrobe.Models
{
    public class Image
    {
        public string Path { get; set; } = String.Empty;
        public int ImageId { get; set; }
        [NotMapped]
        public IFormFile File { get; set; } = null!; // Warns if a null value is given
    }
}
