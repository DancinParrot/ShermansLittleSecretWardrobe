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
    public class IndexModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public IList<Order> Order { get;set; } = default!;
        public IList<Order> OrderUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Order != null)
            {
                IdentityUser user = await _userManager.GetUserAsync(User);

                if (User.IsInRole("Admin"))
                {
                    Order = await _context.Order.ToListAsync();
                }
                else
                {
                    Order = await _context.Order
                                .Where(o => o.UserId == user.Id)
                                .ToListAsync();
                }
            }
        }
    }
}
