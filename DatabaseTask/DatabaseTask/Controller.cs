using DatabaseTask.Db;
using DatabaseTask.Services;
using DatabaseTask.Services.IServices;

namespace DatabaseTask;

public class Controller
{

    private readonly IDepartmentService _department;
    private readonly ILectureService _lecture;
    private readonly IStudentService _student;

    public Controller(DatabaseTaskContext context)
    {
        _department = new DepartmentService(context);
        _lecture = new LectureService(context);
        _student = new StudentService(context);

    }

    public void AssignStudentToDepartment(int departmentId, int studentId)
    {
        var student = _student.GetStudentById(studentId);

        var department = _department.GetAllById(departmentId);

        department.Students.Add(student);

        _department.Update(department);
        _department.Save();
    }

    public void AssignLectureToDepartment(int departmentId, int lectureId)
    {
        var lecture = _lecture.GetWithDepartments(lectureId);

        var department = _department.GetAllById(departmentId);

        department.Lectures.Add(lecture);

        _department.Update(department);
        _department.Save();
    }

    public void DeleteStudent()
    {
        PrintStudents();
        Console.WriteLine("id to remove");
        var student = int.Parse(Console.ReadLine());
        
        _student.Delete(student);
        _department.Save();
    }
    public void PrintStudents()
    {
        var students = _student.GetAll().ToList();

        students.ForEach(x => Console.WriteLine($"ID: {x.Id} -- FullName: {x.Name} {x.LastName} "));
    }

    public void PrintLectures()
    {
        var lectures = _lecture.GetAll().ToList();
        lectures.ForEach(x => Console.WriteLine($"ID: {x.Id} -- Name: {x.Name}"));
    }

    public void PrintDepartments()
    {
        var departments = _department.GetAll().ToList();
        departments.ForEach(x => Console.WriteLine($"ID: {x.Id} -- Name: {x.Name}"));
    }

    public void PrintAllLecturesInDepartment(int id)
    {
        var department = _department.GetAllById(id);

        Console.WriteLine($"Department: {department.Name} has:\n");
        department.Lectures.ForEach(x => Console.WriteLine($"ID: {x.Id} -- Name: {x.Name}"));
    }

    public void PrintAllStudentsInDepartment(int id)
    {
        var department = _department.GetAllById(id);

        Console.WriteLine($"Department: {department.Name} has:\n");
        department.Students.ForEach(x => Console.WriteLine($"ID: {x.Id} -- FullName: {x.Name} {x.LastName} "));
    }

    public void PrintAllLecturesForStudent(int id)
    {
        var student = _student.GetStudentById(id);
        var departmentId = student.Department.Id;
        var department = _department.GetAllById(departmentId);

        Console.WriteLine(
            $"{student.Name} {student.LastName} with ID: {student.Id}, who is in department: {student.Department.Name} has these lectures:\n");

        department.Lectures.ForEach(x => Console.WriteLine($"ID: {x.Id} -- Name: {x.Name}"));

    }

    public void TaskOne()
    {
        Console.WriteLine("insert department name:");
        var name = Console.ReadLine();
        var newDepartment = _department.CreateDepartment(name);

        PrintStudents();
        Console.WriteLine("assign student to created department");
        var student = int.Parse(Console.ReadLine());
        AssignStudentToDepartment(newDepartment.Id, student);

        PrintLectures();
        Console.WriteLine("assign lecture to created department");
        var lecture = int.Parse(Console.ReadLine());
        AssignLectureToDepartment(newDepartment.Id, lecture);
    }

    public void TaskTwo()
    {
        PrintDepartments();
        Console.WriteLine("select department id");
        var id = int.Parse(Console.ReadLine());

        PrintStudents();
        Console.WriteLine("assign student to created department");
        var student = int.Parse(Console.ReadLine());
        AssignStudentToDepartment(id, student);

        PrintLectures();
        Console.WriteLine("assign lecture to created department");
        var lecture = int.Parse(Console.ReadLine());
        AssignLectureToDepartment(id, lecture);
    }

    public void TaskThree()
    {
        Console.WriteLine("Insert lecture name:");
        var lecture = Console.ReadLine();
        var newLecture = _lecture.CreateLecture(lecture);

        PrintDepartments();
        Console.WriteLine("select department id to add lecture to");
        var department = int.Parse(Console.ReadLine());

        AssignLectureToDepartment(department, newLecture.Id);
    }

    public void TaskFour()
    {
        Console.WriteLine("Insert student name and last name");
        var name = Console.ReadLine();
        var lastname = Console.ReadLine();
        var newStudent = _student.CreateStudent(name, lastname);

        PrintDepartments();
        Console.WriteLine("select department id to add student to");
        var department = int.Parse(Console.ReadLine());

        AssignStudentToDepartment(department, newStudent.Id);
    }

    public void TaskFive()
    {
        PrintDepartments();
        Console.WriteLine("select department id to add student to");
        var department = int.Parse(Console.ReadLine());

        PrintStudents();
        Console.WriteLine("choose student to assign to department");
        var student = int.Parse(Console.ReadLine());
        AssignStudentToDepartment(department, student);
    }

    public void TaskSix()
    {
        PrintDepartments();
        Console.WriteLine("choose department from which to print students ");
        var department = int.Parse(Console.ReadLine());

        PrintAllStudentsInDepartment(department);
    }

    public void TaskSeven()
    {
        PrintDepartments();
        Console.WriteLine("choose department from which to print lectures ");
        var department = int.Parse(Console.ReadLine());

        PrintAllLecturesInDepartment(department);
    }

    public void TaskEight()
    {
        PrintStudents();
        Console.WriteLine("choose student for which to print lectures ");
        var student = int.Parse(Console.ReadLine());

        PrintAllLecturesForStudent(1);
    }

    public void Menu()
    {
        Console.WriteLine(
            "[1] - create department, add students and lectures(bonus if lectures already exist in db)\n" +
            "[2] - add students/lectures to existing department\n" +
            "[3] - create lecture, add it to department\n" +
            "[4] - create student, add it to existing department and assign him lectures\n" +
            "[5] - move student to other department(lectures need to be moved also)\n" +
            "[6] - print all students in department\n" +
            "[7] - print all lectures in department\n" +
            "[8] - print all lectures by student\n" +
            "[9] - exit");

        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                TaskOne();
                Console.ReadLine();
                Console.Clear();
                Menu();
                break;
            case 2:
                TaskTwo();
                Console.ReadLine();
                Console.Clear();
                Menu();
                break;
            case 3:
                TaskThree();
                Console.ReadLine();
                Console.Clear();
                Menu();
                break;
            case 4:
                TaskFour();
                Console.ReadLine();
                Console.Clear();
                Menu();
                break;
            case 5:
                TaskFive();
                Console.ReadLine();
                Console.Clear();
                Menu();
                break;
            case 6:
                TaskSix();
                Console.ReadLine();
                Console.Clear();
                Menu();
                break;
            case 7:
                TaskSeven();
                Console.ReadLine();
                Console.Clear();
                Menu();
                break;
            case 8:
                TaskEight();
                Console.ReadLine();
                Console.Clear();
                Menu();
                break;
            case 9:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("try again!");
                break;

        }
    }
}