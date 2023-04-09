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

        }

        public DbSet<Client> Clients { get; }
        public DbSet<Order> Orders { get; }

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
