using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShermansLittleSecretWardrobe.Data;
using ShermansLittleSecretWardrobe.Models;

namespace ShermansLittleSecretWardrobe.Pages.Audit
{
    public class CreateModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;

        public CreateModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AuditRecord AuditRecord { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.AuditRecord == null || AuditRecord == null)
            {
                return Page();
            }

            _context.AuditRecord.Add(AuditRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
