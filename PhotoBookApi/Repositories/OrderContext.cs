using Microsoft.EntityFrameworkCore;
using PhotoBookApi.Models;

namespace PhotoBookApi.Repositories
{
    // Just a DB context to emulate the DB
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> OrderDetails { get; set; }
    }
}