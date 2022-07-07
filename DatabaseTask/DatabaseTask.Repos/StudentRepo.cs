using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos.Base;
using DatabaseTask.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.Repos;

public class StudentRepo : BaseRepo<StudentDbo>, IStudentRepo
{
    public StudentRepo(DatabaseTaskContext context) : base(context)
    {
    }

    public StudentDbo GetWithDepartment(int id) =>
        _context.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
    
    public IEnumerable<StudentDbo> GetAllStudentsAndDepartments() =>
        _context.Students.Include(s => s.Department);
}