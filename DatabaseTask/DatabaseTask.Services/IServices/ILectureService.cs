using DatabaseTask.Db.Entities;

namespace DatabaseTask.Services.IServices;

public interface ILectureService
{
    LectureDbo CreateLecture(string name);
    LectureDbo GetWithDepartments(int id);
    IEnumerable<LectureDbo> GetAll();


    void Delete(int id);
}