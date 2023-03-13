namespace OrdersApiApp.Service.AdditionalInterfaces
{
    public interface IDaoOrderInfo
    {
        Task<IResult> GetOrderInfo(int orderId);
    }
}
