using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShermansLittleSecretWardrobe.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Product title cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Please only enter alphanumerical, whitespace, and -, only.")]
        [Display(Name = "Product Title")]
        public string Title { get; set; } = String.Empty;
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9-,.'\s]+$", ErrorMessage = "Please only enter alphanumerical, whitespace, and special characters of \",.'\" only")]
        [Display(Name = "Product Description")]
        public string Description { get; set; } = String.Empty;

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Product Category")]
        public string Category { get; set; } = String.Empty;

        // Set precision and scale, meaning price can only be $999.99 at max
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        public string Image { get; set; } = String.Empty; // Stores image name

        [NotMapped]
        [MaxFileSize(5 * 1024 * 1024)] // Max file size of 5MB
        [AllowedExtensions(new string[] { ".jpg", ".png" })] // Only accept .jpg and .png
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; } = null!; // Warns if a null value is given

        // For Input Validation of ImageFile (check of file size and type)
        public class MaxFileSizeAttribute : ValidationAttribute
        {
            private readonly int _maxFileSize;
            public MaxFileSizeAttribute(int maxFileSize)
            {
                _maxFileSize = maxFileSize;
            }

            protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
            {
                var file = value as IFormFile;
                if (file != null)
                {
                    if (file.Length > _maxFileSize)
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }

                return ValidationResult.Success;
            }

            public string GetErrorMessage()
            {
                return $"Maximum allowed file size is { _maxFileSize} bytes.";
            }
        }

        public class AllowedExtensionsAttribute : ValidationAttribute
        {
            private readonly string[] _extensions;
            public AllowedExtensionsAttribute(string[] extensions)
            {
                _extensions = extensions;
            }

            protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
            {
                var file = value as IFormFile;
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (!_extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }

                return ValidationResult.Success;
            }

            public string GetErrorMessage()
            {
                return $"This photo extension is not allowed! Please upload an image of type png or jpg.";
            }
        }
    }
}
