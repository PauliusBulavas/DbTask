using DatabaseTask.Db.Entities;

namespace DatabaseTask.Services.IServices;

public interface IStudentService
{
    StudentDbo CreateStudent(string name, string lastName);
    StudentDbo GetStudentById(int id);
    IEnumerable<StudentDbo> GetAll();


    void Delete(int id);
}