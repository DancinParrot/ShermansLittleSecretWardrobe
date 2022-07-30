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
    [AllowAnonymous]
    public class DetailsModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webEnv;

        public DetailsModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context, IWebHostEnvironment webEnv)
        {
            _context = context;
            _webEnv = webEnv;
        }

        public Product Product { get; set; } = default!; 

/*        public async Task<IActionResult> OnPostAsync(int? id)
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

                // Download image of product
                await FileManagement.RetrieveFileFromStorage(Product, "product-images", _webEnv);
            }
            return Page();
        }*/

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

                // Download image of product
                await FileManagement.RetrieveFileFromStorage(Product, "product-images", _webEnv);
            }
            return Page();
        }
    }
}
