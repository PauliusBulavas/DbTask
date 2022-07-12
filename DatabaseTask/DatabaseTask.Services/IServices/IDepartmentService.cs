using DatabaseTask.Db.Entities;

namespace DatabaseTask.Services.IServices;

public interface IDepartmentService
{
    DepartmentDbo CreateDepartment(string name);
    void Save();
    DepartmentDbo GetAllById(int id);
    void Update(DepartmentDbo department);
    IEnumerable<DepartmentDbo> GetAll();


    void Delete(int id);
}