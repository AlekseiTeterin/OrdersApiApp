using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;
using OrdersApiApp.Service.GeneralService;

namespace OrdersApiApp.Service.ClientService
{
    public class DbDaoClient : IDao<Client>
    {
        private readonly ApplicationDbContext _context;
        public DbDaoClient(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.EntityClient.ToListAsync();
        }

        public async Task<Client> Add(Client client)
        {
            await _context.AddAsync(client);
            _context.SaveChanges();
            return client;  
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<Client> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> Update(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
