using Microsoft.EntityFrameworkCore;

namespace ShermansLittleSecretWardrobe.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShermansLittleSecretWardrobe.Data.ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ShermansLittleSecretWardrobe.Data.ApplicationDbContext>>()))
            {
                if (context == null || context.Product == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Title = "White T-Shirt",
                        ReleaseDate = DateTime.Parse("2022-2-12"),
                        Description = "Plain White T-Shirt",
                        Category = "T-Shirt",
                        Price = 7.99M,
                        Image = "WhiteT-Shirt.jpg"
                    },

                    new Product
                    {
                        Title = "Red T-Shirt",
                        ReleaseDate = DateTime.Parse("2022-3-18"),
                        Description = "Plain Red T-Shirt",
                        Category = "T-Shirt",
                        Price = 10.99M,
                        Image = "RedT-Shirt.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
