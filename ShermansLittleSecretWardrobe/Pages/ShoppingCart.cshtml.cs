using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Data;
using ShermansLittleSecretWardrobe.Models;

namespace ShermansLittleSecretWardrobe.Pages
{
    [Authorize(Roles = "Admin, User")]
    public class ShoppingCartModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
        public CartItem CartItem { get; set; }
        public IList<CartItem> CartItems { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, int? qty)
        {
            if (id == null || qty == null )
            {                
                // Means user access the cart directly
                if (_context.Cart != null)
                {
                    // Get CartId from User
                    IdentityUser user = await _userManager.GetUserAsync(User);

                    var cart = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == user.Id);

                    if (cart != null)
                    {
                        Cart = cart;
                        // List everything in the shopping cart of the user
                        if (_context.CartItem != null)
                        {
                            CartItems = await _context.CartItem
                                        .Where(c => c.CartId == Cart.CartId)
                                        .ToListAsync();
                        }
                    }
 
                }
            }

/*            var product = await _context.Product.FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;

                IdentityUser user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return BadRequest();

                }

                var cart = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == user.Id);

                if (cart == null)
                {
                    // Generate a CartId for the User
                    cart = new Cart();
                    cart.UserId = user.Id;

                    _context.Cart.Add(cart);
                    await _context.SaveChangesAsync();
                }

                Cart = cart;

                // Find if there is already the same cart item that exists by comparing ProdcutId and CartId
                var cartItem = await _context.CartItem.FirstOrDefaultAsync(i => i.ProductId == Product.ProductId && i.CartId == Cart.CartId);

                if (cartItem == null)
                {
                    // Create one if does not exist
                    cartItem = new CartItem();
                    cartItem.ProductId = Product.ProductId;
                    cartItem.CartId = Cart.CartId;
                    cartItem.ItemCount = 1;

                    _context.CartItem.Add(cartItem);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // If exists, add the quantity only
                    cartItem.ItemCount += 1;
                }

                CartItem = cartItem;

                // List everything in the shopping cart of the user
                CartItems = await _context.CartItem
                    .Where(c => c.CartId == Cart.CartId)
                    .ToListAsync();
            }*/
            
            /*if (id == null || _context.Cart == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }
            else 
            {
                Cart = cart;
            }*/

            return Page();
        }
    }
}
