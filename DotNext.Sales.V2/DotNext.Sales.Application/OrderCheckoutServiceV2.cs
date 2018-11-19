using DotNext.Sales.Core;

namespace DotNext.Sales.Application
{
    public class OrderCheckoutServiceV2
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly DiscountCalculator _discountCalculator;
        public OrderCheckoutServiceV2(IOrdersRepository ordersRepository, DiscountCalculator discountCalculator)
        {
            _ordersRepository = ordersRepository;
            _discountCalculator = discountCalculator;
        }

        public void Checkout(long orderId)
        {
            var order = _ordersRepository.GetOrder(orderId);
            var discount = _discountCalculator.CalculateDiscountFor(order.CustomerId);
            order.ApplyDiscount(discount);
            order.State = OrderState.AwaitingPayment;
            _ordersRepository.SaveOrder(order);
        }
    }
}