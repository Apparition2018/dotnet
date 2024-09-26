using dotnet.L.Demo;

namespace dotnetTest.Guide.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#join-operations">LINQ - Join operations</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/join-operations">Join 运算</a>
/// </summary>
/// <remarks>
/// 使用交叉联接、组联接和左外联接操作
/// </remarks>
public class JoinOperations : Demo
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/join-operations#perform-inner-joins">内部联接</a>
    /// </summary>
    public class InnerJoin
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/join-operations#composite-key-join">组合键联接</a>
        /// </summary>
        [Test]
        public void CompositeKeyJoin()
        {
            IEnumerable<string> query =
                from teacher in Teachers
                join student in Students on new
                {
                    FirstName = teacher.First,
                    LastName = teacher.Last
                } equals new
                {
                    student.FirstName,
                    student.LastName
                }
                select teacher.First + " " + teacher.Last;

            query = Teachers
                .Join(Students,
                    teacher => new { FirstName = teacher.First, LastName = teacher.Last },
                    student => new { student.FirstName, student.LastName },
                    (teacher, student) => $"{teacher.First} {teacher.Last}"
                );

            string result = $"The following people are both teachers and students:{Environment.NewLine}";
            result = query.Aggregate(result, (current, name) => current + $"{name}\r\n");

            Console.Write(result);
        }
    }


    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/join-operations#perform-grouped-joins">分组联接</a>
    /// </summary>
    public class GroupedJoin
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/join-operations#group-join">分组联接</a>
        /// </summary>
        [Test]
        public void GroupJoin()
        {
            var query = from department in Departments
                join student in Students on department.ID equals student.DepartmentID into studentGroup
                select new
                {
                    DepartmentName = department.Name,
                    Students = studentGroup
                };

            query = Departments.GroupJoin(Students, department => department.ID, student => student.DepartmentID,
                (department, Students) => new { DepartmentName = department.Name, Students });

            foreach (var v in query)
            {
                // Output the department's name.
                Console.WriteLine($"{v.DepartmentName}:");

                // Output each of the students in that department.
                foreach (Student? student in v.Students)
                {
                    Console.WriteLine($"  {student.FirstName} {student.LastName}");
                }
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/join-operations#perform-left-outer-joins">左外部联接</a>
    /// </summary>
    [Test]
    public void LeftOuterJoin()
    {
        var query =
            from student in Students
            join department in Departments on student.DepartmentID equals department.ID into gj
            from subgroup in gj.DefaultIfEmpty()
            select new
            {
                student.FirstName,
                student.LastName,
                Department = subgroup?.Name ?? string.Empty
            };

        query = Students.GroupJoin(Departments, student => student.DepartmentID, department => department.ID,
                (student, departmentList) => new { student, subgroup = departmentList.AsQueryable() })
            .SelectMany(joinedSet => joinedSet.subgroup.DefaultIfEmpty(), (student, department) => new
            {
                student.student.FirstName,
                student.student.LastName,
                Department = department.Name
            });

        foreach (var v in query)
        {
            Console.WriteLine($"{v.FirstName:-15} {v.LastName:-15}: {v.Department}");
        }
    }
}
