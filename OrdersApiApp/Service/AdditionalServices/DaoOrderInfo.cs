using OrdersApiApp.Model;
using OrdersApiApp.Service.AdditionalInterfaces;
using Microsoft.EntityFrameworkCore;

namespace OrdersApiApp.Service.AdditionalServices
{
    public class DaoOrderInfo : IDaoOrderInfo
    {
        private readonly ApplicationDbContext db;

        public DaoOrderInfo(ApplicationDbContext db)
        {
            this.db = db;
        }

        // вывод информации о заказе
        public async Task<IResult> GetOrderInfo(int orderId)
        {
            var order = await db.EntityOrder.FirstOrDefaultAsync(p => p.Id == orderId);

            if (order is null)
            {
                return Results.NotFound(new { message = $"заказ с ID = {orderId} отсутствует" });
            }

            // Получение расшивки с заказом и с данными о продукте
            var orderProducts = db.EntityOrderProduct
                .Where(op => op.OrderId == orderId)
                .Include(p => p.Product);

            // Информaция о заказе
            var orderInfo = new List<string>();

            // Общее количество товаров в заказе
            int productCounter = 0;

            orderInfo.Add($"Описание заказа: {order.Description}");

            foreach (var product in orderProducts)
            {
                orderInfo.Add(
                    $"Наименование товара: {product.Product?.ProductName} | " +
                    $"Количество: {product.ProductQuantity} шт."
                );
                productCounter += product.ProductQuantity;
            }

            orderInfo.Add($"Всего товаров: {productCounter} шт.");

            return Results.Json(orderInfo);
        }
    }
}
