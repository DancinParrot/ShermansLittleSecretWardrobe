using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Data;
using ShermansLittleSecretWardrobe.Models;

namespace ShermansLittleSecretWardrobe.Pages.Audit
{
    public class IndexModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ShermansLittleSecretWardrobeContext _context;

        public IndexModel(ShermansLittleSecretWardrobe.Data.ShermansLittleSecretWardrobeContext context)
        {
            _context = context;
        }

        public IList<AuditRecord> AuditRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AuditRecords != null)
            {
                AuditRecord = await _context.AuditRecords.ToListAsync();
            }
        }
    }
}
