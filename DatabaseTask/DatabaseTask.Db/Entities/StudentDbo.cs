namespace DatabaseTask.Db.Entities;

public class StudentDbo : BaseEntity
{

    public StudentDbo() { }

    public StudentDbo(string name, string lastName)
    {
        Name = name;
        LastName = lastName;
    }

    public string LastName { get; set; }
    public virtual DepartmentDbo? Department { get; set; }
}