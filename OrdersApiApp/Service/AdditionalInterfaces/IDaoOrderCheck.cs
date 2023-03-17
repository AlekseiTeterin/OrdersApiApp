using OrdersApiApp.Model;

namespace OrdersApiApp.Service.AdditionalInterfaces
{
    public interface IDaoOrderCheck
    {
        Check GetOrderCheck(int  orderId);
    }
}
