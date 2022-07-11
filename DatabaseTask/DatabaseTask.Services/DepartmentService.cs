using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos;
using DatabaseTask.Repos.Base.IBase;
using DatabaseTask.Services.IServices;

namespace DatabaseTask.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IBaseRepo<DepartmentDbo> _departmentRepo;

    public DepartmentService(DatabaseTaskContext context) =>
        _departmentRepo = new DepartmentRepo(context);
    
    public DepartmentDbo GetDepartmentById(int id) =>
        _departmentRepo.GetById(id);

    public IEnumerable<DepartmentDbo> GetAll() =>
        _departmentRepo.GetAll();

    public void Save() =>
        _departmentRepo.SaveChanges();

    public void Delete(int id) =>
        _departmentRepo.Delete(id);

    public DepartmentDbo GetAllById(int id) =>
        _departmentRepo.GetById(id);

    public void Update(DepartmentDbo department) =>
        _departmentRepo.Update(department);
    
    public DepartmentDbo CreateDepartment(string name)
    {
        var department = new DepartmentDbo
        {
            Name = name
        };

        _departmentRepo.Add(department);
        _departmentRepo.SaveChanges();
        return department;
    }

    public IEnumerable<DepartmentDbo> GetAllDepartmentsAndLectures() =>
        _departmentRepo.GetAll();
}