using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos;
using DatabaseTask.Repos.Base.IBase;
using DatabaseTask.Services.IServices;

namespace DatabaseTask.Services;

public class StudentService : IStudentService
{
    private readonly IBaseRepo<StudentDbo> _studentRepo;

    public StudentService(DatabaseTaskContext context) =>
        _studentRepo = new StudentRepo(context);

    public StudentDbo GetStudentById(int id) =>
        _studentRepo.GetById(id);

    public IEnumerable<StudentDbo> GetAll() => //base service has
        _studentRepo.GetAll();

    public void Delete(int id) => //base service has
        _studentRepo.Delete(id);

    public StudentDbo CreateStudent(string name, string lastName)
    {
        var student = new StudentDbo
        {
            Name = name,
            LastName = lastName
        };

        _studentRepo.Add(student);
        _studentRepo.SaveChanges();

        return student;
    }

    public void Update(StudentDbo student) => //base service has
        _studentRepo.Update(student);

    public IEnumerable<StudentDbo> GetAllStudentsAndDepartments() =>
        _studentRepo.GetAll();
}