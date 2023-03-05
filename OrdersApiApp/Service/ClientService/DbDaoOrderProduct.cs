using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;
using OrdersApiApp.Service.GeneralService;

namespace OrdersApiApp.Service.ClientService
{
    public class DbDaoOrderProduct : IDao<OrderProduct>
    {
        private readonly ApplicationDbContext _context;
        public DbDaoOrderProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderProduct>> GetAll()
        {
            _context.EntityProduct.Load(); //явная выгрузка всех данных
            _context.EntityOrder.Load();
            return await _context.EntityOrderProduct.ToListAsync();
        }

        public async Task<OrderProduct> GetById(int id)
        {
            _context.EntityProduct.Load();
            _context.EntityOrder.Load();
            OrderProduct? orderProduct = await _context.EntityOrderProduct.SingleOrDefaultAsync(p => p.Id == id);
            return orderProduct!;
        }

        public async Task<OrderProduct> Add(OrderProduct orderProduct)
        {
            await _context.AddAsync(orderProduct);
            _context.SaveChanges();
            return orderProduct;
        }

        public async Task<bool> Delete(int id)
        {
            OrderProduct? orderProduct = await _context.EntityOrderProduct.FindAsync(id);
            _context.EntityOrderProduct.Remove(orderProduct!);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(OrderProduct orderProduct)
        {
            var currentOrderProduct = await _context.EntityOrderProduct.FindAsync(orderProduct.Id);
            currentOrderProduct!.ProductId = orderProduct.ProductId;
            currentOrderProduct!.OrderId = orderProduct.OrderId;
            currentOrderProduct!.ProductQuantity = orderProduct.ProductQuantity;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
