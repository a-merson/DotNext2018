namespace DotNext.Sales.Core
{
    public class DiscountCalculator
    {
        private readonly IOrdersRepository _ordersRepository;
        public DiscountCalculator(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public decimal CalculateDiscountFor(long customerId)
        {
            var completedOrdersCount = _ordersRepository.GetLast3YearsCompletedOrdersCountFor(customerId);
            return DiscountFrom(completedOrdersCount);
        }

        private decimal DiscountFrom(int completedOrdersCount)
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
}