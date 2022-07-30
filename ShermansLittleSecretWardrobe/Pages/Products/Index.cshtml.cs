using System;
using System.Collections.Generic;
using System.Linq;
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
    public class IndexModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webEnv;

        public IndexModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context, IWebHostEnvironment webEnv)
        {
            _context = context;
            _webEnv = webEnv;
        }

        public IList<Product> Product { get;set; } = default!;

        // For search function
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchTitle { get; set; }

        // For Cart Creation and Adding Item to Cart
        public Cart Cart { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                var products = from p in _context.Product
                             select p;

                if (!string.IsNullOrEmpty(SearchString))
                {
                    products = products.Where(s => s.Category.Equals(SearchString));
                }

                if (!string.IsNullOrEmpty(SearchTitle))
                {
                    products = products.Where(s => s.Title.Contains(SearchTitle));
                }

                Product = await products.ToListAsync();

                foreach (var product in Product)
                {
                    // Download image of product
                    await FileManagement.RetrieveFileFromStorage(product, "product-images", _webEnv);
                }
            }
        }

        public async Task OnPostAsync()
        {

        }
    }
}
