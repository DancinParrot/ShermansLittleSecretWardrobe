using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Models;
using ShermansLittleSecretWardrobe.Data;
using Microsoft.AspNetCore.Authorization;

namespace ShermansLittleSecretWardrobe.Pages.Audit
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ShermansLittleSecretWardrobe.Data.ApplicationDbContext _context;

        public IndexModel(ShermansLittleSecretWardrobe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AuditRecord> AuditRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AuditRecord != null)
            {
                AuditRecord = await _context.AuditRecord.ToListAsync();
            }
        }
    }
}
