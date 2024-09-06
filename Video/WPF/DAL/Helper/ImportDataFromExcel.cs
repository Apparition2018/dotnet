using System.Data;
using System.Runtime.Versioning;
using System.Text;
using Models;

namespace DAL.Helper;

/// <summary>
/// 从 Excel 中导入数据
/// </summary>
[SupportedOSPlatform("windows")]
public class ImportDataFromExcel
{
    /// <summary>
    /// 从 Excel 文件中读取数据
    /// </summary>
    public List<Student> GetStudentByExcel(string path)
    {
        List<Student> list = [];
        DataSet ds = OleDbHelper.GetDataSet("select * from [Student$] ", path);
        DataTable dt = ds.Tables[0];
        list.AddRange(from DataRow row in dt.Rows
            select new Student()
            {
                StudentName = row["姓名"].ToString(),
                Gender = row["性别"].ToString(),
                Birthday = Convert.ToDateTime(row["出生日期"]),
                Age = DateTime.Now.Year - Convert.ToDateTime(row["出生日期"]).Year,
                CardNo = row["考勤卡号"].ToString(),
                StudentIdNo = row["身份证号"].ToString(),
                PhoneNumber = row["电话号码"].ToString(),
                StudentAddress = row["家庭住址"].ToString(),
                ClassId = Convert.ToInt32(row["班级编号"])
            });
        return list;
    }

    /// <summary>
    /// 将集合中的对象插入到数据库
    /// </summary>
    public bool Import(List<Student> list)
    {
        List<string> sqlList = [];
        StringBuilder sqlBuilder = new StringBuilder();
        sqlBuilder.Append("insert into Student(studentName,Gender,Birthday,");
        sqlBuilder.Append("StudentIdNo,Age,PhoneNumber,StudentAddress,CardNo,ClassId)");
        sqlBuilder.Append(" values('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8})");
        sqlList.AddRange(list.Select(objStudent => string.Format(sqlBuilder.ToString(),
            objStudent.StudentName, objStudent.Gender, objStudent.Birthday, objStudent.StudentIdNo,
            objStudent.Age, objStudent.PhoneNumber, objStudent.StudentAddress, objStudent.CardNo, objStudent.ClassId)));
        return SqlHelper.UpdateByTran(sqlList);
    }
}
