using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Models;
using ShermansLittleSecretWardrobe.Data;

namespace ShermansLittleSecretWardrobe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ShermansLittleSecretWardrobe.Models.Product>? Product { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Data.CartItem>? CartItem { get; set; }
    }
}