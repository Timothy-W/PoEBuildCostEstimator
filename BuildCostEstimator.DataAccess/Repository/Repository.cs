using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BuildCostEstimator.DataAccess.Data;
using BuildCostEstimator.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BuildCostEstimator.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderedBy = null, string includeProperties = null)
        {
            //Instantiate an IQueryable
            IQueryable<T> query = dbSet;

            // Check if we have a filter
            if (filter != null)
            {
                //update query to include filtered elements
                query = dbSet.Where(filter);
            }

            //Eager loading(?)
            if (includeProperties != null)
            {
                // Split includedProperties strings in an array
                var splitProperties = includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var property in splitProperties)
                {
                    query = query.Include(property);
                }

            }

            //Now order the remaining elements
            if (orderedBy != null)
            {
                query = orderedBy(query);
            }

            var returnVal = query.ToList();

            return returnVal;

        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            //Instantiate an IQueryable
            IQueryable<T> query = dbSet;

            // Check if we have a filter
            if (filter != null)
            {
                //update query to include filtered elements
                query = dbSet.Where(filter);
            }

            //Eager loading(?)
            if (includeProperties != null)
            {
                // Split includedProperties strings in an array
                var splitProperties = includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var property in splitProperties)
                {
                    query = query.Include(property);
                }

            }

            return query.FirstOrDefault();

        }


        public void Remove(int id)
        {
            T entity = dbSet.Find(id);
            Remove(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);

        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
