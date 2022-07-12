using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos;
using DatabaseTask.Repos.Base.IBase;
using DatabaseTask.Services.IServices;

namespace DatabaseTask.Services;

public class LectureService : ILectureService
{
    private readonly IBaseRepo<LectureDbo> _lectureRepo;

    public LectureService(DatabaseTaskContext context) =>
        _lectureRepo = new LectureRepo(context);

    public IEnumerable<LectureDbo> GetAll() =>
        _lectureRepo.GetAll();

    public LectureDbo GetWithDepartments(int id) =>
        _lectureRepo.GetById(id);

    public void Delete(int id) =>
        _lectureRepo.Delete(id);

    public LectureDbo CreateLecture(string name)
    {
        var lecture = new LectureDbo
        {
            Name = name
        };

        _lectureRepo.Add(lecture);
        _lectureRepo.SaveChanges();
        return lecture;
    }
}