﻿using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShermansLittleSecretWardrobe.Models;
using ShermansLittleSecretWardrobe.Utils;
using Microsoft.AspNetCore.Authorization;

namespace ShermansLittleSecretWardrobe.Pages.Products
{
    [Authorize(Roles = "Admin")]
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
            _context.Product.Add(Product);
            //await _context.SaveChangesAsync();
            // Once a record is added, create an audit record
            if (await _context.SaveChangesAsync() > 0)
            {
                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Add Product";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.ProductID = Product.ProductId;
                // Get current logged-in user
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;
                _context.AuditRecord.Add(auditrecord);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
