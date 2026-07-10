using Microsoft.EntityFrameworkCore;

namespace Internship
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}
