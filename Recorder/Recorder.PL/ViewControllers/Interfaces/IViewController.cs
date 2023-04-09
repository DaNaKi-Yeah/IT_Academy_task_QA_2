using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.PL.ViewControllers.Interfaces
{
    public interface IViewController<T>
    {
        public void DisplayAll();
        public void DisplayOne(T item);
        public void EditById();
        public void RemoveById();
        public int GetEntityId();
    }
}
