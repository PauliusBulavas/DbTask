namespace DatabaseTask.Services.Base.IBase;

public interface IBaseService<T>
{
    IEnumerable<T> GetAll();
    void Update(T entity);
    void Delete(int id);
    T Create(T entity);
}