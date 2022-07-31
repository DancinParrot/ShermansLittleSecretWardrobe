using System.ComponentModel.DataAnnotations;

namespace ShermansLittleSecretWardrobe.Models
{
    public class Shipping
    {
        [Key]
        public int ShippingId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Product title cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Please only enter alphanumerical, whitespace, and -, only.")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Product title cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Please only enter alphanumerical, whitespace, and -, only.")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Product title cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9,#\s-]+$", ErrorMessage = "Please only enter alphanumerical, whitespace, -, and \",\", only.")]
        [Display(Name = "Address Line 1")]
        public string? AddressLine1 { get; set; }
        [StringLength(50, ErrorMessage = "Product title cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9,#\s-]+$", ErrorMessage = "Please only enter alphanumerical, whitespace, -, and \",\", only.")]
        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{1,6}$", ErrorMessage = "Please only enter a 6 digit number.")]
        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Product title cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Please only enter alphanumerical, whitespace, and -, only.")]
        [Display(Name = "City")]
        public string? City { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Product title cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Please only enter alphanumerical, whitespace, and -, only.")]
        [Display(Name = "State")]
        public string? State { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Product title cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Please only enter alphanumerical, whitespace, and -, only.")]
        [Display(Name = "Country")]
        public string? Country { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{1,8}$", ErrorMessage = "Please only enter a 6 digit number.")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
    }
}
