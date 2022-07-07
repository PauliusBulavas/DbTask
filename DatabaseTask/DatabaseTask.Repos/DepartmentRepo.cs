using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos.Base;
using DatabaseTask.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.Repos;

public class DepartmentRepo : BaseRepo<DepartmentDbo>, IDepartmentRepo
{
    public DepartmentRepo(DatabaseTaskContext context) : base(context)
    {
    }

    public DepartmentDbo GetWithStudentsLectures(int id) => _context.Departments
        .Include(d => d.Lectures)
        .Include(d => d.Students)
        .FirstOrDefault(d => d.Id == id);

    public IEnumerable<DepartmentDbo> GetAllDepartmentsAndLectures() =>
        _context.Departments.Include(d => d.Lectures);

    public IQueryable<DepartmentDbo> GetAllDepartments()
        => _context.Departments.Select(x => x);
}