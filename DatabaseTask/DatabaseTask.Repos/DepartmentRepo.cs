using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos.Base;
using DatabaseTask.Repos.Base.IBase;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.Repos;

public class DepartmentRepo : BaseRepo<DepartmentDbo>, IBaseRepo<DepartmentDbo>
{
    public DepartmentRepo(DatabaseTaskContext context) : base(context) { }

    public override DepartmentDbo GetById(int id) => _context.Departments
        .Include(d => d.Lectures)
        .Include(d => d.Students)
        .FirstOrDefault(d => d.Id == id) ?? throw new ArgumentNullException($"{nameof(_context.Departments)} was null");

    public override IEnumerable<DepartmentDbo> GetAll() =>
        _context.Departments
            .Include(d => d.Lectures)
            .Include(d => d.Students);
}