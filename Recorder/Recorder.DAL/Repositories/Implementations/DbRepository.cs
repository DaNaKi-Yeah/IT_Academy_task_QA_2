using Microsoft.EntityFrameworkCore;
using Recorder.DAL.DataBase.SQL;
using Recorder.DAL.Entities.Common;
using Recorder.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.DAL.Repositories.Implementations
{
    public class DbRepository<T> : IDbRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;


        public DbRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<T>();
        }


        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToArrayAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Remove(entity);
            });
        }

        public async Task RemoveByIdAsync(int id)
        {
            T entity = _dbSet.FirstOrDefault(x => x.ID == id);
            await RemoveAsync(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            await Task.Run(() =>
            {
                _dbSet.RemoveRange(entities);
            });
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Update(entity);
            });
        }
    }
}
