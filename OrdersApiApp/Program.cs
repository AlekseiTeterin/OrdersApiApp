using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;
using OrdersApiApp.Service.ClientService;
using OrdersApiApp.Service.GeneralService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDao<Client>, DbDaoClient>();
builder.Services.AddTransient<IDao<Order>, DbDaoOrder>();
builder.Services.AddTransient<IDao<Product>, DbDaoProduct>();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

// тестирование операций с таблицей клиента
app.MapGet("/client/all", async (HttpContext context, IDao<Client> dao) =>
{
    return await dao.GetAll();
});
app.MapGet("/client/get", async (HttpContext context, int id, IDao<Client> dao) =>
{
    return await dao.GetById(id);
});
app.MapPost("/client/add", async (HttpContext context, Client client, IDao<Client> dao) =>
{
    return await dao.Add(client);
});
app.MapPost("/client/delete", async (HttpContext context, int id, IDao<Client> dao) =>
{
    return await dao.Delete(id);
});
app.MapPost("/client/update", async (HttpContext context, IDao<Client> dao, Client client) =>
{
    return await dao.Update(client);
});


// тестирование операций с таблицей заказа
app.MapGet("/order/all", async (HttpContext context, IDao<Order> dao) =>
{
    return await dao.GetAll();
});
app.MapGet("/order/get", async (HttpContext context, int id, IDao<Order> dao) =>
{
    return await dao.GetById(id);
});
app.MapPost("/order/add", async (HttpContext context, Order order, IDao<Order> dao) =>
{
    return await dao.Add(order);
});
app.MapPost("/order/delete", async (HttpContext context, int id, IDao<Order> dao) =>
{
    return await dao.Delete(id);
});
app.MapPost("/order/update", async (HttpContext context, IDao<Order> dao, Order order) =>
{
    return await dao.Update(order);
});

// тестирование операций с таблицей продуктов
app.MapGet("/product/all", async (HttpContext context, IDao<Product> dao) =>
{
    return await dao.GetAll();
});
app.MapGet("/product/get", async (HttpContext context, int id, IDao<Product> dao) =>
{
    return await dao.GetById(id);
});
app.MapPost("/product/add", async (HttpContext context, Product product, IDao<Product> dao) =>
{
    return await dao.Add(product);
});
app.MapPost("/product/delete", async (HttpContext context, int id, IDao<Product> dao) =>
{
    return await dao.Delete(id);
});
app.MapPost("/product/update", async (HttpContext context, IDao<Product> dao, Product product) =>
{
    return await dao.Update(product);
});


app.Run();
