using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Data;
using ShermansLittleSecretWardrobe.Models;
using Microsoft.AspNetCore.Authorization;

namespace ShermansLittleSecretWardrobe.Pages.Roles
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
      public ApplicationRole ApplicationRole { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ApplicationRoles == null)
            {
                return NotFound();
            }

            var applicationrole = await _context.ApplicationRoles.FirstOrDefaultAsync(m => m.Id == id);

            if (applicationrole == null)
            {
                return NotFound();
            }
            else 
            {
                ApplicationRole = applicationrole;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.ApplicationRoles == null)
            {
                return NotFound();
            }
            var applicationrole = await _context.ApplicationRoles.FindAsync(id);

            if (applicationrole != null)
            {
                ApplicationRole = applicationrole;
                _context.ApplicationRoles.Remove(ApplicationRole);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
