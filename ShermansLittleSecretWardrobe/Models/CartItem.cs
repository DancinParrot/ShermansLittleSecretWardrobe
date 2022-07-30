using System.ComponentModel.DataAnnotations;

namespace ShermansLittleSecretWardrobe.Models
{
    public class CartItem
    {
        [Key]
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public int ItemCount { get; set; }
        public int CartId { get; set; } // Unique for each user
    }
}
