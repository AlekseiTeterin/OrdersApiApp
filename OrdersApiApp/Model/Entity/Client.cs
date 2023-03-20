using System.Text.Json.Serialization;

namespace OrdersApiApp.Model.Entity
{
    //Сущность клиента
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = ""; // not nullable
        // навигационные свойства
        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; } // заказы клиента

        public Client() 
        {
            Name = "";
        }

        public Client(int id, string name, string pswrd)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
