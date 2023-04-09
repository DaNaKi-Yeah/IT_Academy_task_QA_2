using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Recorder.DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.DAL.DataBase.SQL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            //don't touch.
            //after these lines generate Clients and Orders with their entities
            Clients.FirstOrDefault();
            Orders.FirstOrDefault();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


            string? connectionString = config
                .GetConnectionString("ConnectionString");

            optionsBuilder
                .UseSqlServer(connectionString);
        }
    }
}
