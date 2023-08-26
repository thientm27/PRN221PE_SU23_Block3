
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DataAccessObject.Utils;
using DAOs.Models;

namespace DataAccessObject.DAOs
{
    public abstract class GenericDAO<TEntity>where TEntity : class
    {
        protected readonly CartoonFilm2023DBContext Context;

        public GenericDAO(CartoonFilm2023DBContext context)
        {
            Context = context;
        }
        public List<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                             (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }


        public TEntity Create(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity).Entity;
        }

        public void Update(TEntity entityToUpdate)
        {
            Context.Set<TEntity>().Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public abstract TEntity? GetById(object? id);

        public void DeleteById(object? id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                Delete(entity);
            }

        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entityToDelete);
            }
            Context.Set<TEntity>().Remove(entityToDelete);
        }
        public Pagination<TEntity> ToPagination(IEnumerable<TEntity> list, int pageIndex = 0, int pageSize = 10,
            params Expression<Func<TEntity, object>>[] includes)
        {
            if (list is IQueryable<TEntity> query)
            {
                list = includes.Aggregate(query, (entity, property) => entity.Include(property));
            }

            var result = new Pagination<TEntity>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Items = list.Skip(pageIndex * pageSize).Take(pageSize).ToList(),
                TotalItemsCount = list.Count()
            };

            return result;
        }

    }
}
