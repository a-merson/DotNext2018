using System;
using System.Linq;
using DotNext.Sales.Core;

namespace DotNext.Sales.Application
{
    public class OrderCheckoutService
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrderCheckoutService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public void Checkout(long id)
        {
            var ord = _ordersRepository.GetOrder(id);
            var orders = _ordersRepository.GetOrders()
                                          .Count(o => o.CustomerId == ord.CustomerId
                                                      && o.StateId == 3
                                                      && o.OrderDate >= DateTime.UtcNow.AddYears(-3));

            ord.Price *= (100 - (orders >= 5 ? 30m : orders >= 3 ? 20m : orders >= 1 ? 10m : 0)) / 100;
            ord.StateId = 1;
            _ordersRepository.SaveOrder(ord);
        }

        #region V2

        //public void CheckoutV2(long orderId)
        //{
        //    var order = _ordersRepository.GetOrder(orderId);
        //    var discount = _discountCalculator.CalculateDiscountBy(order.CustomerId);
        //    order.ApplyDiscount(discount);
        //    order.State = OrderState.AwaitingPayment;
        //    _ordersRepository.SaveOrder(order);
        //}

        #endregion
    }

    #region V2

    public class DiscountCalculator
    {
        private readonly IOrdersRepository _ordersRepository;
        public DiscountCalculator(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public decimal CalculateDiscountBy(long customerId)
        {
            var completedOrdersCount = _ordersRepository.GetLast3YearsCompletedOrdersCountFor(customerId);
            return DiscountBy(completedOrdersCount);
        }

        private decimal DiscountBy(int completedOrdersCount)
        {
            if (completedOrdersCount >= 5)
                return 30;

            if (completedOrdersCount >= 3)
                return 20;

            if (completedOrdersCount >= 1)
                return 10;

            return 0;
        }
    }

    #endregion
}
