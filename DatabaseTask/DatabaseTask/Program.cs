using DatabaseTask.Db;

namespace DatabaseTask;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new DatabaseTaskContext();

        var controller = new Controller(context);

        // controller.DeleteStudent();
        // controller.DeleteDepartment();
        // controller.DeleteLecture();

        controller.Menu();
    }
}