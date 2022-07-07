using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos;
using DatabaseTask.Repos.IRepos;
using DatabaseTask.Services.IServices;

namespace DatabaseTask.Services;

public class LectureService : ILectureService
{
    private readonly ILectureRepo _lectureRepo;

    public LectureService(DatabaseTaskContext context)
    {
        _lectureRepo = new LectureRepo(context);
    }

    public IEnumerable<LectureDbo> GetAll() => //base service has
        _lectureRepo.GetAll();

    public LectureDbo GetWithDepartments(int id) =>
        _lectureRepo.GetWithDepartments(id);
    
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