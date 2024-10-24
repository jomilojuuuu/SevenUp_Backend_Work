using Microsoft.EntityFrameworkCore;
using SevenUpClassLib.Models;

namespace SevenUp.Data
{
    public class drinkDb(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<ApplicationUser> applicationUsers { get; set; } = default!;
    }
}
