namespace OrdersApiApp.Model
{
    public class Person
    {
        public string Name { get; set; } = ""; // not nullable
        public string Password { get; set; } = "";

        public Person()
        {
            Name = "";
            Password = "";
        }

        public Person(string name, string pswrd)
        {
            Name = name;
            Password = pswrd;
        }
    }
}
