using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Data;
using ShermansLittleSecretWardrobe.Models;
using ShermansLittleSecretWardrobe.Utils;
using Microsoft.AspNetCore.Authorization;

namespace ShermansLittleSecretWardrobe.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webEnv;

        public DeleteModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context, IWebHostEnvironment webEnv)
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

            var product = await _context.Product.FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.FindAsync(id);

            if (product != null)
            {
                Product = product;
                // Delete image from both Azure Blob Storage and Webroot folder
                FileManagement.DeleteFileFromStorage(product, "product-images", _webEnv);

                // Delete from DB
                _context.Product.Remove(Product);
                await _context.SaveChangesAsync();

                // Once a record is deleted, create an audit record


                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Delete Product";
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
