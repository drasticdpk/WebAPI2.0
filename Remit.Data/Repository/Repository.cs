using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Remit.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Private Member Variables

        private RemitEntities Context;
        private DbSet<T> DbSet;

        #endregion Private Member Variables

        public Repository(RemitEntities context)
        {
            this.Context = context;
            this.DbSet = context.Set<T>();
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(object Id)
        {
            T entityToDelete = DbSet.Find(Id);
            Delete(entityToDelete);
        }

        public void Delete(T entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public void Update(T entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IEnumerable<T> Get()
        {
            IQueryable<T> query = DbSet;
            return query.ToList();
        }

        public T GetByID(object id)
        {
            return DbSet.Find(id);
        }
    }
}