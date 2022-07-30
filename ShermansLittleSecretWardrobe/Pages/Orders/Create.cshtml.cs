using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Models;
using ShermansLittleSecretWardrobe.Utils;

namespace ShermansLittleSecretWardrobe.Pages.Orders
{
    [Authorize(Roles = "Admin, User")]
    public class CreateModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _webEnv;

        public CreateModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webEnv)
        {
            _context = context;
            _userManager = userManager;
            _webEnv = webEnv;
        }

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public string ReferenceId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? productId)
        {
            if (_context.Order != null)
            {
                if (productId == null)
                {
                    // Create order page should not be accessed directly
                    return NotFound();
                }
                else
                {
                    if (_context.Product != null)
                    {
                        var product = await _context.Product.FirstOrDefaultAsync(p => p.ProductId == productId);

                        if (product != null)
                        {

                            // Get product object from db to display info
                            Random random = new Random();

                            Product = product;
                            ReferenceId = String.Format("P{0}ORD{1}", Product.ProductId, NumUtil.RandomString(6));
                            // Download image of product
                            await FileManagement.RetrieveFileFromStorage(Product, "product-images", _webEnv);
                        }
                    }
                }
            }


            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public Shipping Shipping { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string referenceId, int productId)
        {
            /*if (!ModelState.IsValid || _context.Order == null || Order == null || _context.Shipping == null || Shipping == null)
            {
                return NotFound();
            }*/

            if (_context.Order == null || _context.Product == null || _context.Shipping == null)
            {
                return NotFound();
            }

            // Get userId to bind this order to the user
            IdentityUser user = await _userManager.GetUserAsync(User);

            // Get Product

            var product = await _context.Product.FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product != null)
            {
                Product = product;

                Order.ProductId = Product.ProductId;
                Order.PaymentAmount = Product.Price;

            }


            _context.Shipping.Add(Shipping);
            await _context.SaveChangesAsync();

            // Get Shipping ID from DB after adding to DB
            var shipping = await _context.Shipping.FirstOrDefaultAsync(s => s.ShippingId == Shipping.ShippingId);

            if (shipping != null)
            {
                Shipping = shipping;
                Order.UserId = user.Id;
                Order.CreationTimestamp = DateTime.Now;
                Order.OrderStatus = "Pending";
                Order.PaymentMethod = "Paynow";
                Order.ShippingId = Shipping.ShippingId;
                Order.ReferenceId = ReferenceId;

                _context.Order.Add(Order);
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("Receipt", "Order", new { orderId = Order.OrderId });
        }
    }
}
