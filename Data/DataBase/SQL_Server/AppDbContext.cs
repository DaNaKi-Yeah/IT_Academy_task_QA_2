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

        public void Seed()
        {
            if (Clients.Any() || Orders.Any())
                return;

            Client client = new Client()
            {
                ID = 999,
                FirstName = "Nikola",
                SecondName = "Tesla",
                PhoneNumber = "+996703703500",
                OrderAmount = 2,
                DateAdd = DateTime.Now,
            };

            Clients.Add(client);


            Order order = new Order()
            {
                ClientID = client.ID,
                OrderDate = DateTime.Today,
                CloseDate = DateTime.Now,
                Price = 500,
                Description = "Печень"
            };

            Orders.Add(order);

            order = new Order()
            {
                ClientID = client.ID,
                OrderDate = DateTime.Today,
                CloseDate = DateTime.Now,
                Price = 200,
                Description = "Шаверма"
            };

            Orders.Add(order);


            SaveChanges();
        }
    }
}
