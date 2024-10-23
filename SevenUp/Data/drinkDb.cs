using Microsoft.EntityFrameworkCore;
using Seven_up.Library.Models;

namespace Seven_up.Data
{
    public class drinkDb(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<ApplicationUser> applicationUsers { get; set; } = default!;
    }
}
