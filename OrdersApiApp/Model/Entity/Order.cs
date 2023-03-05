using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersApiApp.Model.Entity
{
    public class Order
    {
        public int Id { get; set; } // первичный ключ
        public string Description { get; set; } // описание заказа
        public int ClientId { get; set; } // внешний ключ на клиента
        //навигационные свойства
        public Client? Client { get; set; } // объект клиента, на которого ссылается заказ

        public ICollection<OrderProduct>? OrdersProducts { get; set; }

        public Order()
        {
            Description = "";
        }

        public Order(int id, string descr, int clientId)
        {
            Id = id;
            Description = descr;
            ClientId = clientId;
            
        }

        public override string ToString()
        {
            return $"{Id} - {Description} - {ClientId}";
        }
    }
}
