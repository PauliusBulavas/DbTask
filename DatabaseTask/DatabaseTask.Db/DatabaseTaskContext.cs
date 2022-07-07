using DatabaseTask.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.Db;

public class DatabaseTaskContext : DbContext
{
    public virtual DbSet<DepartmentDbo> Departments { get; set; }
    public virtual DbSet<LectureDbo> Lectures { get; set; }
    public virtual DbSet<StudentDbo> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DatabaseTaskDb;Trusted_Connection=True;");
}