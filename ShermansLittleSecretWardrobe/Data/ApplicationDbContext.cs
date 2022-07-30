using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Models;

namespace ShermansLittleSecretWardrobe.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ShermansLittleSecretWardrobe.Models.Product>? Product { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Models.AuditRecord>? AuditRecord { get; set; }

        public DbSet<ShermansLittleSecretWardrobe.Models.ApplicationRole>? ApplicationRoles { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Models.Order>? Order { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Models.Cart>? Cart { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Models.CartItem>? CartItem { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Models.ApplicationRole>? ApplicationRoles{ get; set; }

    }
}