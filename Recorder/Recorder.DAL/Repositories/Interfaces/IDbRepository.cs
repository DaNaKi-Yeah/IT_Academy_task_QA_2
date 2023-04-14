using Recorder.DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.DAL.Repositories.Interfaces
{
    public interface IDbRepository<TEntity>
    {
        public Task<TEntity> AddAsync(TEntity entity);
        public Task AddRangeAsync(IEnumerable<TEntity> entities);
        public Task<TEntity> GetByIdAsync(int id);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task UpdateAsync(TEntity entity);
        public Task RemoveAsync(TEntity entity);
        public Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        public Task RemoveByIdAsync(int id);
        public Task<int> SaveChangesAsync();
    }
}
