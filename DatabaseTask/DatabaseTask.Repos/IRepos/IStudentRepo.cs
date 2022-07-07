using DatabaseTask.Db.Entities;
using DatabaseTask.Repos.Base.IBase;

namespace DatabaseTask.Repos.IRepos;

public interface IStudentRepo : IBaseRepo<StudentDbo>
{
    StudentDbo GetWithDepartment(int id);
    IEnumerable<StudentDbo> GetAllStudentsAndDepartments();
}