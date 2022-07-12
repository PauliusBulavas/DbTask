using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos.Base;
using DatabaseTask.Repos.Base.IBase;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.Repos;

public class LectureRepo : BaseRepo<LectureDbo>
{
    public LectureRepo(DatabaseTaskContext context) : base(context) { }

    public override LectureDbo GetById(int id) =>
        _context.Lectures.Include(l => l.Departments).FirstOrDefault(d => d.Id == id) ??
        throw new InvalidOperationException($"{nameof(_context.Lectures)} was null");
}