using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Models;

namespace ShermansLittleSecretWardrobe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ShermansLittleSecretWardrobe.Models.Product>? Product { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Models.AuditRecord>? AuditRecord { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Models.ApplicationRole>? ApplicatioinRole { get; set; }

    }
}