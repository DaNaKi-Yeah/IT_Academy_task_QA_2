using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        public TEntity Add(TEntity entity);
        public void AddRange(IEnumerable<TEntity> entities);
        public TEntity GetById(int id);
        public IEnumerable<TEntity> GetAll();
        public void Update(TEntity entity);
        public void Remove(TEntity entity);
        public void RemoveById(int id);
    }
}
