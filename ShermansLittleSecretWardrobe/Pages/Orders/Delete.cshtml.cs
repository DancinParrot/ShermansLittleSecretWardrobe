using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Data;
using ShermansLittleSecretWardrobe.Models;

namespace ShermansLittleSecretWardrobe.Pages.Orders
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;

        public DeleteModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        [BindProperty]
        public Shipping Shipping { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Order == null || _context.Shipping == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FirstOrDefaultAsync(m => m.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;

                var shipping = await _context.Shipping.FindAsync(Order.ShippingId);

                if (shipping != null)
                {
                    Shipping = shipping;

                }

            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Order == null || _context.Shipping == null)
            {
                return NotFound();
            }
            var order = await _context.Order.FindAsync(id);

            if (order != null)
            {
                Order = order;

                var shipping = await _context.Shipping.FindAsync(Order.ShippingId);

                if (shipping != null)
                {
                    Shipping = shipping;


                    _context.Order.Remove(Order);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
