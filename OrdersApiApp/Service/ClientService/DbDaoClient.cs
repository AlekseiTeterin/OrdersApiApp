using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;
using OrdersApiApp.Service.GeneralService;
using System;

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

        public async Task<Client> GetById(int id)
        {
            Client? client = await _context.EntityClient.SingleOrDefaultAsync(p => p.Id == id);
            return client!;
        }

        public async Task<Client> Add(Client client)
        {
            await _context.AddAsync(client);
            _context.SaveChanges();
            return client;  
        }

        public async Task<bool> Delete(int id)
        {
            Client? client = await _context.EntityClient.FindAsync(id);
            _context.EntityClient.Remove(client!);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Client client)
        {
            var currentClient = await _context.EntityClient.FindAsync(client.Id);
            currentClient!.Name = client.Name;
            

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
