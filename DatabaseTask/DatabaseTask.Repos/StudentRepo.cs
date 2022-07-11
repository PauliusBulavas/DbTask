using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos.Base;
using DatabaseTask.Repos.Base.IBase;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.Repos;

public class StudentRepo : BaseRepo<StudentDbo>, IBaseRepo<StudentDbo>
{
    public StudentRepo(DatabaseTaskContext context) : base(context) { }

    public override StudentDbo GetById(int id) =>
        _context.Students.Include(s => s.Department)
            .FirstOrDefault(s => s.Id == id) ??
        throw new InvalidOperationException($"{nameof(_context.Students)} was null");

    public override IEnumerable<StudentDbo> GetAll() =>
        _context.Students.Include(s => s.Department);
}