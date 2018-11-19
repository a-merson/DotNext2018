using Microsoft.EntityFrameworkCore;

namespace DotNext.Sales.Core
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}