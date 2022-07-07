using DatabaseTask.Db.Entities;
using DatabaseTask.Repos.Base.IBase;

namespace DatabaseTask.Repos.IRepos;

public interface IDepartmentRepo : IBaseRepo<DepartmentDbo>
{
    DepartmentDbo GetWithStudentsLectures(int id);
    IEnumerable<DepartmentDbo> GetAllDepartmentsAndLectures();
}