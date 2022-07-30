using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Models;

namespace ShermansLittleSecretWardrobe.Pages.Orders
{

    public class ReceiptModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReceiptModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public Shipping Shipping { get; set; }
        [BindProperty]
        public Product Product  { get; set; }
        public async Task<IActionResult> OnGetAsync(int? orderId)
        {
            if (!ModelState.IsValid || orderId == null)
            {
                return BadRequest();
            }

            if (_context.Order != null && _context.Shipping != null && _context.Product != null)
            {
                var order = await _context.Order.FirstOrDefaultAsync(o => o.OrderId == orderId);

                if (order != null)
                {
                    Order = order;

                    var shipping = await _context.Shipping.FirstOrDefaultAsync(s => s.ShippingId == Order.ShippingId);

                    if (shipping != null)
                    {
                        Shipping = shipping;
                    }

                    var product = await _context.Product.FirstOrDefaultAsync(p => p.ProductId == Order.ProductId);

                    if (product != null)
                    {
                        Product = product;
                    }
                }
            }
            return Page();
        }
    }
}
