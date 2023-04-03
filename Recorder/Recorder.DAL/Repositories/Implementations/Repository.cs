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
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<T>();
        }

        public T Add(T entity)
        {
            var addedEntity = _dbSet.Add(entity).Entity;
            int id = addedEntity.ID;

            _appDbContext.SaveChanges();

            return addedEntity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.ID == id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public void RemoveById(int id)
        {
            bool isHaveClientWithThisId = _dbSet.Any(c => c.ID == id);

            if (isHaveClientWithThisId)
            {
                T entity = _dbSet.FirstOrDefault(e => e.ID == id);
                _dbSet.Remove(entity);
                _appDbContext.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
