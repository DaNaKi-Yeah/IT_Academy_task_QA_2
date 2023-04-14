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
    public class DbRepository<TEntity> : IDbRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<TEntity> _dbSet;


        public DbRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<TEntity>();
        }


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            //он возвращает ордера без нового id
            return (await _dbSet.AddAsync(entity)).Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToArrayAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Remove(entity);
            });
        }

        public async Task RemoveByIdAsync(int id)
        {
            TEntity entity = _dbSet.FirstOrDefault(x => x.ID == id);
            await RemoveAsync(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() =>
            {
                _dbSet.RemoveRange(entities);
            });
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Update(entity);
            });
        }
    }
}
