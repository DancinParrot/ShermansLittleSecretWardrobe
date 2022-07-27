using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Data;
using ShermansLittleSecretWardrobe.Helper;
using ShermansLittleSecretWardrobe.Utils;

namespace ShermansLittleSecretWardrobe.Pages.ShoppingCart
{
    public class CartModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webEnv;

        public CartModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context, IWebHostEnvironment webEnv)
        {
            _context = context;
            _webEnv = webEnv;
        }

        public IList<CartItem> CartItem { get;set; } = default!;
        public decimal Total { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.CartItem != null)
            {
                CartItem = SessionHelper.GetObjectFromJson<IList<CartItem>>(HttpContext.Session, "cart");
                Total = CartItem.Sum(i => i.Product.Price * i.Quantity);
                CartItem = await _context.CartItem
                .Include(c => c.Product).ToListAsync();

                foreach (var cartItem in CartItem)
                {
                    // Download image of product and store is wwwroot/data
                    await FileManagement.RetrieveFileFromStorage(cartItem.Product, "product-images", _webEnv);
                }
            }
        }
    }
}
