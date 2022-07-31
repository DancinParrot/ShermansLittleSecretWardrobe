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
        //public DbSet<ShermansLittleSecretWardrobe.Models.AuditRecord>? AuditRecord { get; set; }

        

        public DbSet<ShermansLittleSecretWardrobe.Models.ApplicationRole>? ApplicationRoles { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Models.Order>? Order { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Models.Cart>? Cart { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Models.CartItem>? CartItem { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Models.Shipping>? Shipping { get; set; }
        public DbSet<ShermansLittleSecretWardrobe.Models.AuditRecord>? AuditRecord { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string adminID = "1";
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = adminID,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    CreatedDate = DateTime.Now,
                    IPAddress = "127.0.0.1",
                    Description = "Administrator role (Authorized to do anything)"
                });
            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser()
                {
                    Id = adminID,
                    Email = "RealAdmin@gmail.com",
                    NormalizedEmail = "REALADMIN@GMAIL.COM",
                    NormalizedUserName = "REALADMIN@GMAIL.COM",
                    UserName = "RealAdmin@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "adminP@ssw0rd")
                }); ;
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = adminID,
                    UserId = adminID
                });
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole()
                {
                    Name = "Users",
                    NormalizedName = "USERS",
                    CreatedDate = DateTime.Now,
                    IPAddress = "127.0.0.2",
                    Description = "Basic User Role"
                });
        }

    }
}