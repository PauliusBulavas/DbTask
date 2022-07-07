using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos.Base.IBase;
using DatabaseTask.Services.Base.IBase;

namespace DatabaseTask.Services.Base;

public class BaseService<T> : IBaseService<T> where T : BaseEntity
{
    // private readonly IBaseRepo<T> _repo;
    //
    // protected BaseService(IBaseRepo<T> repo)
    // {
    //     _repo = repo;
    // }
    
    internal readonly IBaseRepo<T> _repo;

    protected BaseService(IBaseRepo<T> repo)
    {
        _repo = repo;
    }

    public virtual IEnumerable<T> GetAll() =>
        _repo.GetAll();

    public virtual void Update(T entity) =>
        _repo.Update(entity);

    public void Delete(int id) =>
        _repo.Delete(id);

}