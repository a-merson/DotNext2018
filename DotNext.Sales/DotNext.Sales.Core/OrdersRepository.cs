using System;
using System.Linq;

namespace DotNext.Sales.Core
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly SalesDbContext _dbContext;
        public OrdersRepository(SalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order GetOrder(long orderId)
        {
            return _dbContext.Orders.SingleOrDefault(o => o.Id == orderId);
        }

        public void SaveOrder(Order order)
        {
            var dbOrder = _dbContext.Orders.Find(order.Id);
            _dbContext.Entry(dbOrder).CurrentValues.SetValues(order);
            _dbContext.SaveChanges();
        }

        public IQueryable<Order> GetOrders()
        {
            return _dbContext.Orders;
        }

        #region V2

        public int GetLast3YearsCompletedOrdersCountFor(long customerId)
        {
            var threeYearsAgo = DateTime.UtcNow.AddYears(-3);
            return _dbContext.Orders
                             .Count(o => o.CustomerId == customerId
                                         && o.State == OrderState.Completed
                                         && o.OrderDate >= threeYearsAgo);
        }
        #endregion
    }
}