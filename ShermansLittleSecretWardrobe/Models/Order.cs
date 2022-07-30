using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShermansLittleSecretWardrobe.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CartId { get; set; }
        public string? OrderStatus { get; set; }
        public string? UserId { get; set; }
        public int ShippingId { get; set; }
        [Required]
        [Display(Name = "Order Creation Timestamp")]
        [DataType(DataType.DateTime)]
        public DateTime? CreationTimestamp { get; set; }

        [Display(Name = "Order Creation Timestamp")]
        [DataType(DataType.DateTime)]
        public DateTime? PaymentTimestamp { get; set; }

        [Required]
        public string? PaymentMethod { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? PaymentAmount { get; set; }

    }
}
