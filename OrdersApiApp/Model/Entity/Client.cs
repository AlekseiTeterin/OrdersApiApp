namespace OrdersApiApp.Model.Entity
{
    //Сущность клиента
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = ""; // not nullable


        public Client() 
        {
            Name = "";
        }

        public Client(int id, string name)
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
