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
        public Task UpdateAsync(T entity);
        public Task RemoveAsync(T entity);
        public Task RemoveRangeAsync(IEnumerable<T> entities);
        public Task RemoveByIdAsync(int id);
        public Task<int> SaveChangesAsync();
    }
}
