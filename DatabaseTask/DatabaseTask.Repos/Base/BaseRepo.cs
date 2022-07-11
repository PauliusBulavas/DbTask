using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos.Base.IBase;

namespace DatabaseTask.Repos.Base;

public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
{
    internal readonly DatabaseTaskContext _context;

    protected BaseRepo(DatabaseTaskContext context) =>
        _context = context;


    public virtual void Delete(int id)
    {
        var entity = GetById(id);
        _context.Set<T>().Remove(entity);
    }

    public virtual void Add(T entity) =>
        _context.Set<T>().Add(entity);

    public virtual T GetById(int id) =>
        _context.Set<T>().Find(id) ?? throw new ArgumentNullException($"{typeof(T)} was null");

    public virtual IEnumerable<T> GetAll() =>
        _context.Set<T>().Select(x => x);

    public virtual void Update(T entity) =>
        _context.Update(entity);

    public virtual void SaveChanges() =>
        _context.SaveChanges();
}