using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Models;
using ShermansLittleSecretWardrobe.Data;

namespace ShermansLittleSecretWardrobe.Pages.Audit
{
    public class DetailsModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;

        public DetailsModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AuditRecord AuditRecord { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AuditRecord == null)
            {
                return NotFound();
            }

            var auditrecord = await _context.AuditRecord.FirstOrDefaultAsync(m => m.Audit_ID == id);
            if (auditrecord == null)
            {
                return NotFound();
            }
            else 
            {
                AuditRecord = auditrecord;
            }
            return Page();
        }
    }
}
