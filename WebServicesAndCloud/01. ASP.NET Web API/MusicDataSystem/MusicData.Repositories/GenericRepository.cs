namespace MusicData.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext context;
        private IDbSet<T> entitySet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.entitySet = context.Set<T>();
        }

        public T Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return this.entitySet;
        }

        public IQueryable<T> Find(Expression<Func<T, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }

        public T Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
            return entity;
        }

        public T Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
            return entity;
        }

        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.entitySet.Attach(entity);
            }

            entry.State = state;
        }
    }
}