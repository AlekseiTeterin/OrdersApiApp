using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using OrdersApiApp.JwtConfiguration;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;
using OrdersApiApp.Service.AdditionalInterfaces;
using OrdersApiApp.Service.AdditionalServices;
using OrdersApiApp.Service.ClientService;
using OrdersApiApp.Service.GeneralService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


var people = new List<Person>
 {
    new Person("tom@gmail.com", "12345"),
    new Person("bob@gmail.com", "55555")
};

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = AuthOptions.ISSUER,
            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = AuthOptions.AUDIENCE,
            // будет ли валидироваться время существования
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddTransient<IDao<Client>, DbDaoClient>();
builder.Services.AddTransient<IDao<Order>, DbDaoOrder>();
builder.Services.AddTransient<IDao<Product>, DbDaoProduct>();
builder.Services.AddTransient<IDao<OrderProduct>, DbDaoOrderProduct>();

builder.Services.AddTransient<IDaoOrderInfo, DaoOrderInfo>();
builder.Services.AddTransient<IDaoOrderCheck, DaoOrderCheck>();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/login", (Person loginData) =>
 {
     // находим пользователя 
     Person? person = people.FirstOrDefault(p => p.Name == loginData.Name && p.Password == loginData.Password);
     // если пользователь не найден, отправляем статусный код 401
     if (person is null) return Results.Unauthorized();

     var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Name) };
     // создаем JWT-токен
     var jwt = new JwtSecurityToken(
             issuer: AuthOptions.ISSUER,
             audience: AuthOptions.AUDIENCE,
             claims: claims,
             expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
             signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
     var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

     // формируем ответ
     var response = new
     {
         access_token = encodedJwt,
         username = person.Name
     };

     return Results.Json(response);
 });

app.MapGet("/", () => "Hello World!");

// тестирование операций с таблицей клиента
app.MapGet("/client/all_jwt", [Authorize] async (HttpContext context, IDao<Client> dao) =>
{
    return await dao.GetAll();
});app.MapGet("/client/all", async (HttpContext context, IDao<Client> dao) =>
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

// тестирование операций с таблицей продукта
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

// тестирование операций с таблицей заказ-товар
app.MapGet("/order_product/all", async (HttpContext context, IDao<OrderProduct> dao) =>
{
    return await dao.GetAll();
});
app.MapGet("/order_product/get", async (HttpContext context, int id, IDao<OrderProduct> dao) =>
{
    return await dao.GetById(id);
});
app.MapPost("/order_product/add", async (HttpContext context, OrderProduct orderProduct, IDao<OrderProduct> dao) =>
{
    return await dao.Add(orderProduct);
});
app.MapPost("/order_product/delete", async (HttpContext context, int id, IDao<OrderProduct> dao) =>
{
    return await dao.Delete(id);
});
app.MapPost("/order_product/update", async (HttpContext context, IDao<OrderProduct> dao, OrderProduct orderProduct) =>
{
    return await dao.Update(orderProduct);
});

//тестирование запроса на получение информации о товаре
app.MapGet("/order/info", async (HttpContext context, IDaoOrderInfo dao, int id) =>
{
    return await dao.GetOrderInfo(id);
});
//тестирование запроса на получение чека с заказом
app.MapGet("/order/check", (HttpContext context, IDaoOrderCheck dao, int id) =>
{
    return dao.GetOrderCheck(id).ToString();
});

app.Run();
