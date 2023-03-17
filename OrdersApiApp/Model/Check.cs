using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Model
{
    public class Check
    {
        public List<OrderProduct> OrderProducts;
        public decimal Price;

        public Check(List<OrderProduct> _OrderProducts, decimal _Price)
        {
            OrderProducts = _OrderProducts;
            Price = _Price;
        }

        public override string ToString()
        {
            string text = "";
            foreach (var product in OrderProducts)
            {
                text += " " + product.Product!.ProductName + "\t\t" + product.Product.ProductPrice + "*" + product.ProductQuantity + " = " +
                    product.Product.ProductPrice* product.ProductQuantity + " руб." + "\n";
            }

            return $"{text} \n\n итого: {Price} рублей.";
        }
    }
}
