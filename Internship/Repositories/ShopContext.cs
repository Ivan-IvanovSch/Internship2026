using Internship.Models;
using Microsoft.EntityFrameworkCore;

namespace Internship.Repositories
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
