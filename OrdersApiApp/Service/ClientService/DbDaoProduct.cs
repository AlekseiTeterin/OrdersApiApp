using OrdersApiApp.Model.Entity;
using OrdersApiApp.Model;
using OrdersApiApp.Service.GeneralService;
using Microsoft.EntityFrameworkCore;

namespace OrdersApiApp.Service.ClientService
{
    public class DbDaoProduct : IDao<Product>
    {
        private readonly ApplicationDbContext _context;
        public DbDaoProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.EntityProduct.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            Product? product = await _context.EntityProduct.SingleOrDefaultAsync(p => p.Id == id);
            return product!;
        }

        public async Task<Product> Add(Product product)
        {
            await _context.AddAsync(product);
            _context.SaveChanges();
            return product;
        }

        public async Task<bool> Delete(int id)
        {
            Product? product = await _context.EntityProduct.FindAsync(id);
            _context.EntityProduct.Remove(product!);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Product product)
        {
            var currentProduct = await _context.EntityProduct.FindAsync(product.Id);
            currentProduct!.ProductName = product.ProductName;
            currentProduct!.ProductPrice = product.ProductPrice;
            currentProduct!.ItemNumber = product.ItemNumber;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
