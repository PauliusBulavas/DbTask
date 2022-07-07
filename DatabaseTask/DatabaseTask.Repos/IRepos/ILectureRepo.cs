using DatabaseTask.Db.Entities;
using DatabaseTask.Repos.Base.IBase;

namespace DatabaseTask.Repos.IRepos;

public interface ILectureRepo : IBaseRepo<LectureDbo>
{
    LectureDbo GetWithDepartments(int id);
}