using System.Linq.Expressions;

namespace WManagementSystem.infrastructure
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);

        T GetValue(Guid id);
        IEnumerable<T> All();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void SaveChanges();
    }
}
