using DatabaseTask.Db.Entities;

namespace DatabaseTask.Services.IServices;

public interface IDepartmentService
{
    DepartmentDbo CreateDepartment(string name);
    DepartmentDbo GetDepartmentById(int id);
    void Save();
    DepartmentDbo GetAllById(int id);
    void Update(DepartmentDbo department);
    IEnumerable<DepartmentDbo> GetAll();


    void Delete(int id);
}