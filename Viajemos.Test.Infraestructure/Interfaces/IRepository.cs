using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Viajemos.Test.Book.Infraestructure.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> query);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> query, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> query, Expression<Func<TEntity, object>> order, bool ascedent, params Expression<Func<TEntity, object>>[] includes);
        TEntity Find(int key);
        TEntity Find(Expression<Func<TEntity, bool>> query, params Expression<Func<TEntity, object>>[] includes);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int key);
    }
}
