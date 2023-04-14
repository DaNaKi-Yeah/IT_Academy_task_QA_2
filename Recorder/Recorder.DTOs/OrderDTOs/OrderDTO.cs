using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ClientID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CloseDate { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
