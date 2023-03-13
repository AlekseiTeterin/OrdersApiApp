using System.Text.Json.Serialization;

namespace OrdersApiApp.Model.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = ""; // not nullable
        public decimal ProductPrice { get; set; }
        public int ItemNumber { get; set; }
        [JsonIgnore]
        public ICollection<OrderProduct>? OrdersProducts { get; set; }


        public Product()
        {
            ProductName = "";
            ProductPrice = 0;
            ItemNumber = -1;
        }

        public Product(int id, string name, decimal price,  int number)
        {
            Id = id;
            ProductName = name;
            ProductPrice = price;
            ItemNumber = number;
        }

        public override string ToString()
        {
            return $"{Id} - {ProductName} - {ProductPrice}- {ItemNumber}";
        }
    }
}
