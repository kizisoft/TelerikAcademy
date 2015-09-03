namespace MusicData.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);

        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, int, bool>> predicate);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        void Detach(T entity);

        void SaveChanges();
    }
}