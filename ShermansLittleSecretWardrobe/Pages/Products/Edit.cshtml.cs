using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Data;
using ShermansLittleSecretWardrobe.Models;
using ShermansLittleSecretWardrobe.Utils;

namespace ShermansLittleSecretWardrobe.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webEnv;

        public EditModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context, IWebHostEnvironment webEnv)
        {
            _context = context;
            _webEnv = webEnv;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }
                
            var product =  await _context.Product.FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            Product = product;

            // Download image of product
            await FileManagement.RetrieveFileFromStorage(Product, "product-images", _webEnv);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Product.ImageFile.Length > 0)
            {
                // Save image to Microsoft Azure
                using (var memoryStream = new MemoryStream())
                {
                    await Product.ImageFile.CopyToAsync(memoryStream);
                    String fileName = Regex.Replace(Product.Title, @"\s+", "") + Path.GetExtension(Product.ImageFile.FileName);
                    // Upload to Azure Blob Storage (Strip white space off product name to set as image name)
                    await FileManagement.UploadFileToStorage(memoryStream, fileName, "product-images");

                    // Set image attribute in Product object
                    Product.Image = fileName;

                    // Clear memory stream
                    memoryStream.SetLength(0);
                }

                /*Directory.CreateDirectory(Path.Combine(_hostenvironment.ContentRootPath, "uploadfiles")); // Will automatically check for existence of directory
                using (var stream = new FileStream(Path.Combine(_hostenvironment.ContentRootPath, "uploadfiles", Product.ImageFile.FileName), FileMode.Create))
                {
                    await Product.ImageFile.CopyToAsync(stream);
                }*/
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
