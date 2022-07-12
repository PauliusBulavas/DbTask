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

    private void AssignStudentToDepartment(int departmentId, int studentId)
    {
        var student = _student.GetStudentById(studentId);

        var department = _department.GetAllById(departmentId);

        department.Students.Add(student);

        _department.Update(department);
        _department.Save();
    }

    private void AssignLectureToDepartment(int departmentId, int lectureId)
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
        int.TryParse(Console.ReadLine(), out var id);

        _student.Delete(id);
        _department.Save();
    }

    public void DeleteLecture()
    {
        PrintLectures();
        Console.WriteLine("id to remove");
        int.TryParse(Console.ReadLine(), out var id);

        _lecture.Delete(id);
        _department.Save();
    }

    public void DeleteDepartment()
    {
        PrintDepartments();
        Console.WriteLine("id to remove");
        int.TryParse(Console.ReadLine(), out var id);

        _department.Delete(id);
        _department.Save();
    }



    private void PrintStudents()
    {
        var students = _student.GetAll().ToList();

        students.ForEach(x => Console.WriteLine($"ID: {x.Id} -- FullName: {x.Name} {x.LastName} "));
    }

    private void PrintLectures()
    {
        var lectures = _lecture.GetAll().ToList();
        lectures.ForEach(x => Console.WriteLine($"ID: {x.Id} -- Name: {x.Name}"));
    }

    private void PrintDepartments()
    {
        var departments = _department.GetAll().ToList();
        departments.ForEach(x => Console.WriteLine($"ID: {x.Id} -- Name: {x.Name}"));
    }

    private void PrintAllLecturesInDepartment(int id)
    {
        var department = _department.GetAllById(id);

        Console.WriteLine($"Department: {department.Name} has:\n");
        department.Lectures.ForEach(x => Console.WriteLine($"ID: {x.Id} -- Name: {x.Name}"));
    }

    private void PrintAllStudentsInDepartment(int id)
    {
        var department = _department.GetAllById(id);

        Console.WriteLine($"Department: {department.Name} has:\n");
        department.Students.ForEach(x => Console.WriteLine($"ID: {x.Id} -- FullName: {x.Name} {x.LastName} "));
    }

    private void PrintAllLecturesForStudent(int id)
    {
        var student = _student.GetStudentById(id);
        var departmentId = student.Department.Id;
        var department = _department.GetAllById(departmentId);

        Console.WriteLine(
            $"{student.Name} {student.LastName} with ID: {student.Id}, who is in department: {student.Department.Name} has these lectures:\n");

        department.Lectures.ForEach(x => Console.WriteLine($"ID: {x.Id} -- Name: {x.Name}"));

    }

    private void TaskOne()
    {
        Console.WriteLine("insert department name:");
        var name = Console.ReadLine();
        var newDepartment = _department.CreateDepartment(name);

        PrintStudents();
        Console.WriteLine("assign student to created department");
        int.TryParse(Console.ReadLine(), out var student);
        AssignStudentToDepartment(newDepartment.Id, student);

        PrintLectures();
        Console.WriteLine("assign lecture to created department");
        int.TryParse(Console.ReadLine(), out var lecture);
        AssignLectureToDepartment(newDepartment.Id, lecture);
    }

    private void TaskTwo()
    {
        PrintDepartments();
        Console.WriteLine("select department id");
        var id = int.Parse(Console.ReadLine());

        PrintStudents();
        Console.WriteLine("assign student to created department");
        int.TryParse(Console.ReadLine(), out var student);
        AssignStudentToDepartment(id, student);

        PrintLectures();
        Console.WriteLine("assign lecture to created department");
        int.TryParse(Console.ReadLine(), out var lecture);
        AssignLectureToDepartment(id, lecture);
    }

    private void TaskThree()
    {
        Console.WriteLine("Insert lecture name:");
        var lecture = Console.ReadLine();
        var newLecture = _lecture.CreateLecture(lecture);

        PrintDepartments();
        Console.WriteLine("select department id to add lecture to");
        int.TryParse(Console.ReadLine(), out var department);

        AssignLectureToDepartment(department, newLecture.Id);
    }

    private void TaskFour()
    {
        Console.WriteLine("Insert student name and last name");
        var name = Console.ReadLine();
        var lastname = Console.ReadLine();
        var newStudent = _student.CreateStudent(name, lastname);

        PrintDepartments();
        Console.WriteLine("select department id to add student to");
        int.TryParse(Console.ReadLine(), out var department);

        AssignStudentToDepartment(department, newStudent.Id);
    }

    private void TaskFive()
    {
        PrintDepartments();
        Console.WriteLine("select department id to add student to");
        int.TryParse(Console.ReadLine(), out var department);

        PrintStudents();
        Console.WriteLine("choose student to assign to department");
        int.TryParse(Console.ReadLine(), out var student);
        AssignStudentToDepartment(department, student);
    }

    private void TaskSix()
    {
        PrintDepartments();
        Console.WriteLine("choose department from which to print students ");
        int.TryParse(Console.ReadLine(), out var department);

        PrintAllStudentsInDepartment(department);
    }

    private void TaskSeven()
    {
        PrintDepartments();
        Console.WriteLine("choose department from which to print lectures ");
        int.TryParse(Console.ReadLine(), out var department);

        PrintAllLecturesInDepartment(department);
    }

    private void TaskEight()
    {
        PrintStudents();
        Console.WriteLine("choose student for which to print lectures ");
        int.TryParse(Console.ReadLine(), out var student);

        PrintAllLecturesForStudent(student);
    }


    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("[1] - create department, add students and lectures(bonus if lectures already exist in db)\n"
                              + "[2] - add students/lectures to existing department\n"
                              + "[3] - create lecture, add it to department\n"
                              + "[4] - create student, add it to existing department and assign him lectures\n"
                              + "[5] - move student to other department(lectures need to be moved also)\n"
                              + "[6] - print all students in department\n"
                              + "[7] - print all lectures in department\n"
                              + "[8] - print all lectures by student\n"
                              + "[9] - exit");

            int.TryParse(Console.ReadLine(), out var selection);
            
            switch (selection)
            {
                case 1:
                    TaskOne();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 2:
                    TaskTwo();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 3:
                    TaskThree();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 4:
                    TaskFour();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 5:
                    TaskFive();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 6:
                    TaskSix();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 7:
                    TaskSeven();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 8:
                    TaskEight();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("try again!");
                    continue;
            }
            break;
        }
    }
}