using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Data;
using ShermansLittleSecretWardrobe.Models;

namespace ShermansLittleSecretWardrobe.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DetailsModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

      public Order Order { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Order == null)
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

                IdentityUser user = await _userManager.GetUserAsync(User);

                // If user is not admin, check if the user id matches the one on the order
                if (!User.IsInRole("Admin"))
                {
                    // If doesn't match, means that user trying to access other user's order
                    // Reject the request
                    if (Order.UserId != user.Id)
                    {
                        return NotFound();
                    }
                }

            }

            return Page();
        }
    }
}
