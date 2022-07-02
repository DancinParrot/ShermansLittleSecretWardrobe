using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShermansLittleSecretWardrobe.Data;
using ShermansLittleSecretWardrobe.Models;
using ShermansLittleSecretWardrobe.Utils;

namespace ShermansLittleSecretWardrobe.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;
        private readonly IHostEnvironment _hostenvironment;

        public CreateModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context, IHostEnvironment webHostEnvironment)
        {
            _context = context;
            _hostenvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Product == null || Product == null)
            {
                return Page();
            }

            if (Product.ImageFile.Length > 0)
            {
                // Save image to Microsoft Azure
                using (var memoryStream = new MemoryStream())
                {
                    await Product.ImageFile.CopyToAsync(memoryStream);

                    // Upload to Azure Blob Storage
                    await FileManagement.UploadFileToStorage(memoryStream, Product.ProductId.ToString() + Path.GetExtension(Product.ImageFile.FileName), "product-images");

                    // Set image attribute in Product object
                    Product.Image = Product.ProductId.ToString() + Path.GetExtension(Product.ImageFile.FileName);
                }

                /*Directory.CreateDirectory(Path.Combine(_hostenvironment.ContentRootPath, "uploadfiles")); // Will automatically check for existence of directory
                using (var stream = new FileStream(Path.Combine(_hostenvironment.ContentRootPath, "uploadfiles", Product.ImageFile.FileName), FileMode.Create))
                {
                    await Product.ImageFile.CopyToAsync(stream);
                }*/
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
