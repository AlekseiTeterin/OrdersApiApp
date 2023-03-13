namespace OrdersApiApp.Service.AdditionalInterfaces
{
    public interface IDaoOrderCheck
    {
        Task<IResult> GetOrderCheck(int  orderId);
    }
}
