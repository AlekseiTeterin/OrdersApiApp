using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;
using OrdersApiApp.Service.AdditionalInterfaces;


namespace OrdersApiApp.Service.AdditionalServices
{
    public class DaoOrderCheck : IDaoOrderCheck
    {
        private readonly ApplicationDbContext _context;

        public DaoOrderCheck(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод вывода суммы заказа
        public Check GetOrderCheck(int orderId)
        {
            //var order = await _context.EntityOrder.FirstOrDefaultAsync(p => p.Id == orderId);

            //if (order is null)
            //{
            //    return Results.NotFound(new { message = $"заказ с ID = {orderId} не оформлен" });
            //}

            List<OrderProduct> newCheck = _context.EntityOrderProduct.Where(el => el.OrderId == orderId).Include(p => p.Product).ToList();

            decimal totalSum = 0;

            foreach (var product in newCheck)
            {
                totalSum += product.ProductQuantity * product.Product!.ProductPrice;
            }
            return new Check(newCheck, totalSum);

            //// Получение расшивки с заказом и с данными о продукте
            //var orderProducts = _context.EntityOrderProduct
            //    .Where(op => op.OrderId == orderId)
            //    .Include(p => p.Product);

            //// Чек заказа
            //var check = new List<string>();

            //// Общая сумма заказа
            //decimal totalSum = 0;

            //check.Add($"Описание заказа: {order.Description}");

            //foreach (var product in orderProducts)
            //{
            //    check.Add(
            //        $"Товар: {product.Product?.ProductName} | " +
            //        $"{product.ProductQuantity} шт. | " +
            //        $"Цена: {product.Product?.ProductPrice} руб./ед."
            //    );
            //    totalSum += product.ProductQuantity * product.Product!.ProductPrice;
            //}

            //check.Add($"Общая сумма заказа: {totalSum} рублей.");

            //return Results.Json(check);
        }
    }
}
