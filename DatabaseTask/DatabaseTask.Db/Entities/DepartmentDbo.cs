namespace DatabaseTask.Db.Entities;

public class DepartmentDbo : BaseEntity
{

    public DepartmentDbo() { }

    public DepartmentDbo(string name)
    {
        Name = name;
        Lectures = new List<LectureDbo>();
        Students = new List<StudentDbo>();
    }

    public virtual List<LectureDbo> Lectures { get; set; }
    public virtual List<StudentDbo> Students { get; set; }
}