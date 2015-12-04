using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccess
{
    public class GenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbset;

        protected readonly Context Context;


        public GenericRepository(Context context)
        {
            Context = context;
            _dbset = context.Set<T>();
        }


        public virtual T GetById(object id)
        {
            return _dbset.Find(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return _dbset.ToList();
        }

        public IQueryable<T> GetQuery(params Expression<Func<T, object>>[] includes)
        {
            return includes.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(_dbset, (current, include) => current.Include(include));
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Set<T>().Remove(entity);
        }

        public void DeleteAll(IEnumerable<T> entities)
        {
            var entitiesArray = entities.ToArray();
            foreach (var entity in entitiesArray)
            {
                Delete(entity);
            }
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
    }
}
