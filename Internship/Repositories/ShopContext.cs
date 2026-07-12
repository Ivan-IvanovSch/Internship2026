using Internship.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Internship.Repositories
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();

        public DbSet<Account> Accounts => Set<Account>();
    }
}
