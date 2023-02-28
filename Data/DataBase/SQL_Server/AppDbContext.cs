using Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Data.DataBase.SQL_Server
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        //метод который, вызывается при добавлении заказа в таблицу заказов,
        //который обновляет свойство OrderAmount для записей в таблице Clients

        public void Seed()
        {
            if (Clients.Any() || Orders.Any())
                return;

            Client client = new Client()
            {
                FirstName = "Nikola",
                SecondName = "Tesla",
                PhoneNumber = "+996703703500",
                OrderAmount = 2,
                DateAdd = DateTime.Now,
            };

            Clients.Add(client);


            Order order = new Order()
            {
                OrderDate = DateTime.Today,
                CloseDate = DateTime.Now,
                Price = 500,
                Description = "Печень"
            };

            Orders.Add(order);

            order = new Order()
            {
                OrderDate = DateTime.Today,
                CloseDate = DateTime.Now,
                Price = 200,
                Description = "Шаверма"
            };

            Orders.Add(order);


            SaveChanges();
        }

        public void UpdateOrderAmountsForClients()
        {
            foreach (Client client in Clients)
            {
                client.OrderAmount = CountOrders(client.ID);
            }

            SaveChanges();
        }
        private uint CountOrders(uint clientId)
        {
            List<Order> list = new List<Order>();

            if (Orders != null || Clients != null)
            {
                list = Orders.Where(x => x.ClientID == clientId).ToList();
            }
            uint count = (uint)list.Count();

            return count;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string? connectionString = config.GetConnectionString("ConnectionString");

            optionsBuilder
                .UseSqlServer(connectionString);
        }

        
    }
}
