﻿using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Model

{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> EntityClient { get; set; }
        public DbSet<Order> EntityOrder { get; set; }
        public DbSet<Product> EntityProduct { get; set; }
        public DbSet<OrderProduct> EntityOrderProduct { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            // инициализируем саму строку подключения
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
