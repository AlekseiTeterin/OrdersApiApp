using System.Text.Json.Serialization;

namespace OrdersApiApp.Model.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = ""; // not nullable
        public int ItemNumber { get; set; }
        [JsonIgnore]
        public ICollection<OrderProduct>? OrdersProducts { get; set; }


        public Product()
        {
            ProductName = "";
            ItemNumber = -1;
        }

        public Product(int id, string name, int number)
        {
            Id = id;
            ProductName = name;
            ItemNumber = number;
        }

        public override string ToString()
        {
            return $"{Id} - {ProductName} - {ItemNumber}";
        }
    }
}
