using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos.Base;
using DatabaseTask.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.Repos;

public class LectureRepo : BaseRepo<LectureDbo>, ILectureRepo
{
    public LectureRepo(DatabaseTaskContext context) : base(context)
    {
    }

    public LectureDbo GetWithDepartments(int id) =>
        _context.Lectures.Include(l => l.Departments).FirstOrDefault(d => d.Id == id);
}