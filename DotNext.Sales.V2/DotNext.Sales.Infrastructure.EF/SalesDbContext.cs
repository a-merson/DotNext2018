using DotNext.Sales.Core;
using Microsoft.EntityFrameworkCore;

namespace DotNext.Sales.Infrastructure.EF
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}
