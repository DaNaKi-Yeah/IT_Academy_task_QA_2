using Recorder.DAL.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.DAL.Entities.Models
{
    public class Order : BaseEntity
    {
        public Order() { }
        public Order(int clientID, double price, string description, DateTime orderDate, DateTime closeDate)
        {
            ClientID = clientID;
            Price = price;
            Description = description;
            OrderDate = orderDate;
            CloseDate = closeDate;
        }

        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CloseDate { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
