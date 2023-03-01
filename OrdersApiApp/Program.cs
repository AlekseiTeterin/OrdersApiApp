using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;
using OrdersApiApp.Service.ClientService;
using OrdersApiApp.Service.GeneralService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDao<Client>, DbDaoClient>();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

// ������������ �������� � �������� �������
app.MapGet("/client/all", async (HttpContext context, IDao<Client> dao) =>
{
    return await dao.GetAll();
});

app.MapPost("/client/add", async (HttpContext context, Client client, IDao<Client> dao) =>
{
    return await dao.Add(client);
});

app.Run();
