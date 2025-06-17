using System.Linq.Expressions;
using WManagementSystem.infrastructure;

namespace WarehouseManagementSystem.Web;

public abstract class GenericRepository<T> : IRepository<T> where T : class
{
    protected WarehouseContext context;

    public GenericRepository(WarehouseContext context)
    {
        this.context = context;
    }
    public T Add(T entity)
    {
        var addedEntity = context.Add(entity).Entity;

        return addedEntity;
    }

    public IEnumerable<T> All()
    {
       var all = context.Set<T>().ToList();

        return all;
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        var result = context.Set<T>().AsQueryable()
            .Where(predicate)
            .ToList();

        return result;
    }

    public T GetValue(Guid id)
    {
        return context.Find<T>(id);
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }

    public T Update(T entity)
    {
        return context.Update(entity).Entity;
    }
}
