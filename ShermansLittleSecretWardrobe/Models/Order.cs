using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShermansLittleSecretWardrobe.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Please only enter alphanumerical, whitespace, and -, only.")]
        public string? OrderStatus { get; set; }
        public string UserId { get; set; }
        public int ShippingId { get; set; }
        [Required]
        [Display(Name = "Order Creation Timestamp")]
        [DataType(DataType.DateTime)]
        public DateTime? CreationTimestamp { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Please only enter alphanumerical, whitespace, and -, only.")]
        public string? PaymentMethod { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        [RegularExpression(@"^[0-9.]+$", ErrorMessage = "Please only enter alphanumerical, and \".\", only.")]
        public decimal? PaymentAmount { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZZ0-9]{1,15}$")]
        public string? ReferenceId { get; set; }

    }
}
