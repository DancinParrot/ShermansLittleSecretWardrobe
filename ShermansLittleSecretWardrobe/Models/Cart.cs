using System.ComponentModel.DataAnnotations;

namespace ShermansLittleSecretWardrobe.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public string UserId { get; set; }
    }
}
