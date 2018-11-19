namespace DotNext.Sales.Core
{
    public enum OrderState
    {
        Created = 0,
        AwaitingPayment = 1,
        Paid = 2,
        Completed = 3
    }
}