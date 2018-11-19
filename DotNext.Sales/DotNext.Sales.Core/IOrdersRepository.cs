using System.Linq;

namespace DotNext.Sales.Core
{
    public interface IOrdersRepository
    {
        Order GetOrder(long id);
        void SaveOrder(Order order);
        IQueryable<Order> GetOrders();

        #region V2
        int GetLast3YearsCompletedOrdersCountFor(long customerId);
        #endregion
    }
}