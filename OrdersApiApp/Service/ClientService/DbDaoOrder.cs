using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;
using OrdersApiApp.Service.GeneralService;

namespace OrdersApiApp.Service.ClientService
{
    public class DbDaoOrder : IDao<Order>
    {
        private readonly ApplicationDbContext _context;
        public DbDaoOrder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAll()
        {
            _context.EntityClient.Load(); //явная выгрузка всех данных
            return await _context.EntityOrder.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.EntityOrder.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Order> Add(Order order)
        {
            await _context.AddAsync(order);
            _context.SaveChanges();
            return order;
        }

        public async Task<bool> Delete(int id)
        {
            Order? order = await _context.EntityOrder.FindAsync(id);
            _context.EntityOrder.Remove(order!);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Order order)
        {
            var currentOrder = await _context.EntityOrder.FindAsync(order.Id);
            currentOrder!.Description = order.Description;
            currentOrder!.ClientId = order.ClientId;

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
