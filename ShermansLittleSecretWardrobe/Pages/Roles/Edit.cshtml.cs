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
using Microsoft.AspNetCore.Authorization;

namespace ShermansLittleSecretWardrobe.Pages.Roles
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;

        public EditModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context)
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

            var applicationrole =  await _context.ApplicationRoles.FirstOrDefaultAsync(m => m.Id == id);
            if (applicationrole == null)
            {
                return NotFound();
            }
            ApplicationRole = applicationrole;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ApplicationRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationRoleExists(ApplicationRole.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ApplicationRoleExists(string id)
        {
          return (_context.ApplicationRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
