using Microsoft.EntityFrameworkCore;
using Recorder.DAL.DataBase.SQL;
using Recorder.DAL.Entities.Common;
using Recorder.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.DAL.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var addedEntity = _dbSet.Add(entity).Entity;
            int id = addedEntity.ID;

            _appDbContext.SaveChanges();

            return addedEntity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.ID == id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public void RemoveById(int id)
        {
            bool isHaveClientWithThisId = _dbSet.Any(c => c.ID == id);

            if (isHaveClientWithThisId)
            {
                TEntity entity = _dbSet.FirstOrDefault(e => e.ID == id);
                _dbSet.Remove(entity);
                _appDbContext.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
