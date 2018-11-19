using System;
using DotNext.Sales.Application;
using DotNext.Sales.Core;
using DotNext.Sales.Infrastructure.EF;

namespace DotNext.Sales.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var checkoutService = new OrderCheckoutServiceV2(new OrdersRepository(new SalesDbContext()), new DiscountCalculator(new OrdersRepository(new SalesDbContext())));
            checkoutService.Checkout(42);
        }
    }
}
