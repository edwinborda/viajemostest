using Microsoft.EntityFrameworkCore;
using Viajemos.Test.Book.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Viajemos.Test.Book.Infraestructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields

        private readonly Context context;

        #endregion

        #region Constructors

        public Repository(Context context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Delete(int key)
        {
            var entity = Find(key);
            context.Set<TEntity>().Remove(entity);
        }

        public TEntity Find(int key)
        {
            return context.Set<TEntity>().Find(key);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> query, params Expression<Func<TEntity, object>>[] includes)
        {
            var queryable = context.Set<TEntity>().AsQueryable();

            return includes.Aggregate(queryable, (current, include) => current.Include(include)).FirstOrDefault(query);
        }

        public IEnumerable<TEntity> Get()
        {
            return context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Get(params Expression<Func<TEntity, object>>[] includes)
        {
            var queryable = context.Set<TEntity>().AsQueryable();

            return includes.Aggregate(queryable, (current, include) => current.Include(include)).ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> query)
        {
            return context.Set<TEntity>().Where(query).ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> query, params Expression<Func<TEntity, object>>[] includes)
        {
            var queryable = context.Set<TEntity>().AsQueryable();

            return includes.Aggregate(queryable, (current, include) => current.Include(include)).Where(query).ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> query, Expression<Func<TEntity, object>> order, bool ascedent, params Expression<Func<TEntity, object>>[] includes)
        {
            var queryable = context.Set<TEntity>().AsQueryable();

            return ascedent ? includes.Aggregate(queryable, (current, include) => current.Include(include)).Where(query).OrderBy(order).ToList()
                            : includes.Aggregate(queryable, (current, include) => current.Include(include)).Where(query).OrderByDescending(order).ToList();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        } 

        #endregion

    }
}
