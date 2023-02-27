using Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public T Add(T entity); //C
        public List<T> AddAll(IEnumerable<T> entities); //C
        public List<T> GetAll(); //C
        public T GetById(uint id); //R
        public void Update(T entity); //U
        public void Delete(T entity); //D
    }
}
