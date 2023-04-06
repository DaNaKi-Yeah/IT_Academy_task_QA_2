using Recorder.DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.PL.ViewControllers.Interfaces
{
    public interface IOrderViewController : IViewController<Order>
    {
        public void DisplayAll(IEnumerable<Order> orders);
        public void Add(int clientId);
    }
}
