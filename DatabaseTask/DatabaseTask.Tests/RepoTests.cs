using DatabaseTask.Db;
using DatabaseTask.Db.Entities;
using DatabaseTask.Repos;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DatabaseTask.Tests;

public class RepoTests
{
    [Fact]
    public void Test_GetAllLecturesWithDepartments()
    {
        var data = new List<DepartmentDbo>
        {
            new()
            {
                Name = "AAA"
            },
            new()
            {
                Name = "BBB"
            },
            new()
            {
                Name = "CCC"
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<DepartmentDbo>>();
        mockSet.As<IQueryable<DepartmentDbo>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<DepartmentDbo>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<DepartmentDbo>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<DepartmentDbo>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<DatabaseTaskContext>();
        mockContext.Setup(c => c.Departments).Returns(mockSet.Object);

        var service = new DepartmentRepo(mockContext.Object);
        var departments = service.GetAllDepartments().ToList();


        Assert.Equal(3, departments.Count);
        Assert.Equal("AAA", departments[0].Name);
        Assert.Equal("BBB", departments[1].Name);
        Assert.Equal("CCC", departments[2].Name);
    }

    [Fact]
    public void Test_GetAllDepartmentsAndLectures()
    {
        var lectureList = new List<LectureDbo>
        {
            new()
            {
                Name = "aaa"
            },
            new()
            {
                Name = "bbb"
            }
        };

        var data = new List<DepartmentDbo>
        {
            new()
            {
                Name = "AAA",
                Lectures = lectureList
            },
            new()
            {
                Name = "BBB",
                Lectures = lectureList
            },
            new()
            {
                Name = "CCC",
                Lectures = lectureList
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<DepartmentDbo>>();
        mockSet.As<IQueryable<DepartmentDbo>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<DepartmentDbo>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<DepartmentDbo>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<DepartmentDbo>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<DatabaseTaskContext>();
        mockContext.Setup(c => c.Departments).Returns(mockSet.Object);

        var service = new DepartmentRepo(mockContext.Object);
        var departments = service.GetAllDepartmentsAndLectures().ToList();

        Assert.Equal(3, departments.Count);
        Assert.Equal("AAA", departments[0].Name);
        Assert.Equal("BBB", departments[1].Name);
        Assert.Equal("CCC", departments[2].Name);
        Assert.Equal(lectureList, departments[0].Lectures);
        Assert.Equal(lectureList, departments[1].Lectures);
        Assert.Equal(lectureList, departments[2].Lectures);

    }

    [Fact]
    public void Test_GetWithStudentsLectures()
    {
        var studentList = new List<StudentDbo>
        {
            new()
            {
                Name = "a",
                LastName = "a"
            },
            new()
            {
                Name = "b",
                LastName = "b"
            },
            new()
            {
                Name = "c",
                LastName = "c"
            }
        };

        var lectureList = new List<LectureDbo>
        {
            new()
            {
                Name = "aaa"
            },
            new()
            {
                Name = "bbb"
            }
        };

        var data = new List<DepartmentDbo>
        {
            new()
            {
                Name = "AAA",
                Lectures = lectureList,
                Students = studentList
            },
            new()
            {
                Name = "BBB",
                Lectures = lectureList,
                Students = studentList
            },
            new()
            {
                Name = "CCC",
                Lectures = lectureList,
                Students = studentList
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<DepartmentDbo>>();
        mockSet.As<IQueryable<DepartmentDbo>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<DepartmentDbo>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<DepartmentDbo>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<DepartmentDbo>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<DatabaseTaskContext>();
        mockContext.Setup(c => c.Departments).Returns(mockSet.Object);

        var service = new DepartmentRepo(mockContext.Object);
        var department = service.GetWithStudentsLectures(0);

        Assert.Equal("AAA", department.Name);
        Assert.Equal(lectureList, department.Lectures);
        Assert.Equal(studentList, department.Students);
    }

    [Fact]
    public void Test_GetWithDepartments()
    {
        var departmentList = new List<DepartmentDbo>
        {
            new()
            {
                Name = "aaa"
            },
            new()
            {
                Name = "bbb"
            }
        };

        var data = new List<LectureDbo>
        {
            new()
            {
                Name = "AAA",
                Departments = departmentList
            },
            new()
            {
                Name = "BBB",
                Departments = departmentList
            },
            new()
            {
                Name = "CCC",
                Departments = departmentList
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<LectureDbo>>();
        mockSet.As<IQueryable<LectureDbo>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<LectureDbo>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<LectureDbo>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<LectureDbo>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<DatabaseTaskContext>();
        mockContext.Setup(c => c.Lectures).Returns(mockSet.Object);

        var service = new LectureRepo(mockContext.Object);
        var lecture = service.GetWithDepartments(0);

        Assert.Equal("AAA", lecture.Name);
        Assert.Equal(departmentList, lecture.Departments);
    }

    [Fact]
    public void Test_GetWithDepartment()
    {
        var department = new DepartmentDbo
        {
            Name = "ABC"
        };

        var data = new List<StudentDbo>
        {
            new()
            {
                Name = "AAA",
                LastName = "BBB",
                Department = department
            },
            new()
            {
                Name = "BBB",
                LastName = "CCC",
                Department = department
            },
            new()
            {
                Name = "CCC",
                LastName = "DDD",
                Department = department
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<StudentDbo>>();
        mockSet.As<IQueryable<StudentDbo>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<StudentDbo>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<StudentDbo>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<StudentDbo>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<DatabaseTaskContext>();
        mockContext.Setup(c => c.Students).Returns(mockSet.Object);

        var service = new StudentRepo(mockContext.Object);
        var student = service.GetWithDepartment(0);

        Assert.Equal("AAA", student.Name);
        Assert.Equal("BBB", student.LastName);
        Assert.Equal(department, student.Department);
    }

    [Fact]
    public void Test_GetAllStudentsAndDepartments()
    {
        var department = new DepartmentDbo
        {
            Name = "ABC"
        };

        var data = new List<StudentDbo>
        {
            new()
            {
                Name = "a",
                LastName = "a",
                Department = department
            },
            new()
            {
                Name = "b",
                LastName = "b",
                Department = department
            },
            new()
            {
                Name = "c",
                LastName = "c",
                Department = department
            }
        }.AsQueryable();


        var mockSet = new Mock<DbSet<StudentDbo>>();
        mockSet.As<IQueryable<StudentDbo>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<StudentDbo>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<StudentDbo>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<StudentDbo>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<DatabaseTaskContext>();
        mockContext.Setup(c => c.Students).Returns(mockSet.Object);

        var service = new StudentRepo(mockContext.Object);
        var students = service.GetAllStudentsAndDepartments().ToList();

        Assert.Equal(3, students.Count);
        Assert.Equal("a", students[0].Name);
        Assert.Equal("b", students[1].Name);
        Assert.Equal("c", students[2].Name);
        Assert.Equal(department, students[0].Department);
        Assert.Equal(department, students[1].Department);
        Assert.Equal(department, students[2].Department);
    }
}