namespace OrdersApiApp.Model.Entity
{
    public class OrderProduct
    {
        public int Id { get; set; } // первичный ключ
        public int ProductId { get; set; } // внешний ключ на товар
        public int OrderId { get; set; } // внешний ключ на заказ

        public int ProductQuantity { get; set; } // количество товара
        //навигационные свойства
        public Product? Product { get; set; } // объект товара, на которого ссылается заказ
        public Order? Order { get; set; } // объект заказа, на которого ссылается заказ

        public OrderProduct()
        {
            ProductQuantity = 0;
        }

        public override string ToString()
        {
            return $"{Id} - {ProductId} - {OrderId} - {ProductQuantity}";
        }
    }
}
