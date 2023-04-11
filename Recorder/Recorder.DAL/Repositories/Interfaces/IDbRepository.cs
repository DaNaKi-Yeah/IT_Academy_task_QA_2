using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.DAL.Repositories.Interfaces
{
    public interface IDbRepository<T>
    {
        public Task AddAsync(T entity);
        public Task AddRangeAsync(IEnumerable<T> entities);
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task Update(T entity);
        public Task Remove(T entity);
        public Task RemoveRange(IEnumerable<T> entities);
        public Task RemoveById(int id);
        public Task<int> SaveChangesAsync();
    }
}
