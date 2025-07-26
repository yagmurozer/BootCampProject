
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Repositories.EntityFramework;

    public abstract class EfRepositoryBase<TEntity, TEntityId, TContext> : IRepository<TEntity, TEntityId>
    where TEntity : BaseEntity<TEntityId>
    where TContext : DbContext
    {

        protected readonly TContext Context; // sadece inherit alınacağı sınıflarda geçerli olması için protected alındı.

        public EfRepositoryBase(TContext context)// cons
        {
            Context = context;
        }

        public IQueryable<TEntity> Query() => Context.Set<TEntity>(); // get işlemleri için

        public TEntity Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow; 
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            entity.DeletedDate = DateTime.UtcNow;
            Context.Remove(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, 
            IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (include != null)
                queryable = include(queryable);
            return queryable.FirstOrDefault(predicate);// ilk veriyi veya defaultu çağırır
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (include != null)
                queryable = include(queryable);
            if (predicate != null)
                queryable = queryable.Where(predicate);
            return queryable.ToList();

        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Update(entity);
            Context.SaveChanges(); // işlemleri kalıcı olarak veri tabanına kaydetti
            return entity;
        }

    }
