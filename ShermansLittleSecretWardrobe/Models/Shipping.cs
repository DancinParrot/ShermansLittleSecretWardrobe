using System.ComponentModel.DataAnnotations;

namespace ShermansLittleSecretWardrobe.Models
{
    public class Shipping
    {
        [Key]
        public int ShippingId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int PostalCode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int PhoneNumber { get; set; }
    }
}
