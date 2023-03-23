using Data.DataBase.SQL_Server;
using Data.Models.Common;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;


        public Repository( )
        {
            _context = new AppDbContext();
        }
        public Repository(AppDbContext context)
        {
            _context = context;
        }


        public T Add(T entity)
        {
            if (entity is null)
            {
                return default(T);
            }


            DbSet<T> dbSet = _context.Set<T>();
            if (dbSet is null)
            {
                return default(T);
            }


            T result = dbSet.Add(entity).Entity;
            _context.SaveChanges();

            return entity;
        }
        public List<T> AddAll(IEnumerable<T> entities)
        {
            if (entities is null)
            {
                return default(List<T>);
            }


            DbSet<T> dbSet = _context.Set<T>();
            if (dbSet is null)
            {
                return default(List<T>);
            }


            List<T> result = new List<T>();
            foreach (T entity in entities)
            {
                 T item = dbSet.Add(entity).Entity;
                result.Add(item);
            }

            _context.SaveChanges();

            return result;
        }

        public T GetById(uint id)
        {
            DbSet<T> dbSet = _context.Set<T>();
            if (dbSet is null)
            {
                return default(T);
            }

            T result = dbSet.FirstOrDefault(entity => entity.ID == id);

            return result;
        }
        public List<T> GetAll()
        {
            DbSet<T> dbSet = _context.Set<T>();
            if (dbSet is null)
            {
                return default(List<T>);
            }

            return dbSet.ToList();
        }


        public void Update(T entity)
        {
            DbSet<T> dbSet = _context.Set<T>();
            if (dbSet is null)
            {
                return;
            }

            dbSet.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            DbSet<T> dbSet = _context.Set<T>();
            if (dbSet is null)
            {
                return;
            }

            dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
