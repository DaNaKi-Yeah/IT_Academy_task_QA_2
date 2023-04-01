using Recorder.DAL.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.DAL.Entities.Models
{
    public class Client : BaseEntity
    {
        public DateTime DateAdd { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual IEnumerable<Order> Orders{ get; set; }
        public int OrderAmount => Orders.Count();
    }
}
