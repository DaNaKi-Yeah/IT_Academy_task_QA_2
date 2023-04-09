using Recorder.DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.PL.ViewControllers.Interfaces
{
    public interface IClientViewController : IViewController<Client>
    {
        public void ShowClientOrders(int clientId);
        public void Add();
    }
}
