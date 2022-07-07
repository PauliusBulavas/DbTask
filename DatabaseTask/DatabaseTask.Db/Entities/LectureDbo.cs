namespace DatabaseTask.Db.Entities;

public class LectureDbo : BaseEntity
{

    public LectureDbo() { }

    public LectureDbo(string name)
    {
        Name = name;
        Departments = new List<DepartmentDbo>();

    }

    public virtual List<DepartmentDbo> Departments { get; set; }
}