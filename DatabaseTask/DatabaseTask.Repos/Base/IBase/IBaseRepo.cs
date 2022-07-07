namespace DatabaseTask.Repos.Base.IBase;

public interface IBaseRepo<T>
{
    void Add(T entity);
    void Delete(int id);
    T GetById(int id);
    IEnumerable<T> GetAll();
    void SaveChanges();
    void Update(T entity);
}