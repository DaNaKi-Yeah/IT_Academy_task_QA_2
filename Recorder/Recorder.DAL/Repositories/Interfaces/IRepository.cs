using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public T Add(T entity);
        public void AddRange(IEnumerable<T> entities);
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public void Update(T entity);
        public void Remove(T entity);
        public void RemoveById(int id);
    }
}
