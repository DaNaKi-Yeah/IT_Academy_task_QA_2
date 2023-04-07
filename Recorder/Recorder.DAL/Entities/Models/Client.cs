using Recorder.DAL.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.DAL.Entities.Models
{
    public class Client : BaseEntity
    {
        public Client() { }
        public Client(string firstName, string secondName, string phoneNumber, DateTime dateAdd)
        {
            FirstName = firstName;
            SecondName = secondName;
            PhoneNumber = phoneNumber;
            DateAdd = dateAdd;
        }

        public DateTime DateAdd { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
        public int OrderAmount => Orders is null ? 0 : Orders.Count();
    }
}
