using System.Data.SqlClient;
using System.Data.SQLite;
using System.Text;
using DAL.Helper;
using Models;
using Models.Ext;

namespace DAL;

/// <summary>
/// 班级服务类
/// </summary>
public class StudentService
{
    /// <summary>
    /// 判断身份证号是否已经存在
    /// </summary>
    public bool IsIdNoExisted(string studentIdNo)
    {
        string sql = $"select count(*) from Student where StudentIdNo={studentIdNo}";
        int result = Convert.ToInt32(SQLiteHelper.GetSingleResult(sql));
        return result == 1;
    }

    /// <summary>
    /// 判断卡号是否已经存在
    /// </summary>
    public bool IsCardNoExisted(string cardNo)
    {
        string sql = $"select count(*) from Student where CardNo={cardNo}";
        int result = Convert.ToInt32(SQLiteHelper.GetSingleResult(sql));
        return result == 1;
    }

    #region 添加学员对象

    /// <summary>
    /// 添加学员对象
    /// </summary>
    public int AddStudent(Student objStudent)
    {
        //【1】编写SQL语句
        StringBuilder sqlBuilder = new StringBuilder();
        sqlBuilder.Append("insert into Student(studentName,Gender,Birthday,");
        sqlBuilder.Append("StudentIdNo,Age,PhoneNumber,StudentAddress,CardNo,ClassId,StuImage)");
        sqlBuilder.Append(" values('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8},'{9}');select @@Identity");
        //【2】解析对象
        string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
            objStudent.Gender, objStudent.Birthday.ToString("yyyy-MM-dd"),
            objStudent.StudentIdNo, objStudent.Age,
            objStudent.PhoneNumber, objStudent.StudentAddress, objStudent.CardNo,
            objStudent.ClassId, objStudent.StuImage);
        try
        {
            //【3】执行SQL语句，返回结果
            return Convert.ToInt32(SQLiteHelper.GetSingleResult(sql));
        }
        catch (SqlException ex)
        {
            throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
        }
    }

    #endregion

    #region 查询学员信息

    /// <summary>
    /// 根据班级查询学员信息
    /// </summary>
    public List<StudentExt> GetStudentByClass(string className)
    {
        string sql = "select StudentId,StudentName,Gender,PhoneNumber,StudentIdNo,Birthday,ClassName from Student";
        sql += " inner join StudentClass on Student.ClassId=StudentClass.ClassId ";
        sql += " where ClassName='{0}'";
        sql = string.Format(sql, className);
        SQLiteDataReader reader = SQLiteHelper.GetReader(sql);
        List<StudentExt> list = [];
        while (reader.Read())
        {
            list.Add(new StudentExt()
            {
                StudentId = Convert.ToInt32(reader["StudentId"]),
                StudentName = reader["StudentName"].ToString()!,
                Gender = reader["Gender"].ToString()!,
                PhoneNumber = reader["PhoneNumber"].ToString()!,
                Birthday = Convert.ToDateTime(reader["Birthday"]),
                StudentIdNo = reader["StudentIdNo"].ToString()!,
                ClassName = reader["ClassName"].ToString()!
            });
        }

        reader.Close();
        return list;
    }

    /// <summary>
    /// 根据学生编号查询学生信息
    /// </summary>
    public StudentExt? GetStudentById(string studentId)
    {
        return GetStudent($" where StudentId={studentId}");
    }

    /// <summary>
    /// 根据卡号查询学生信息
    /// </summary>
    public StudentExt? GetStudentByCardNo(string cardNo)
    {
        return GetStudent($" where CardNo='{cardNo}'");
    }

    private StudentExt? GetStudent(string whereSql)
    {
        string sql = "select StudentId,StudentName,Gender,Birthday,ClassName,";
        sql += "StudentIdNo,PhoneNumber,StudentAddress,CardNo,StuImage from Student";
        sql += " inner join StudentClass on Student.ClassId=StudentClass.ClassId ";
        sql += whereSql;
        SQLiteDataReader reader = SQLiteHelper.GetReader(sql);
        StudentExt? objStudent = null;
        if (reader.Read())
        {
            objStudent = new StudentExt
            {
                StudentId = Convert.ToInt32(reader["StudentId"]),
                StudentName = reader["StudentName"].ToString()!,
                Gender = reader["Gender"].ToString()!,
                Birthday = Convert.ToDateTime(reader["Birthday"]),
                ClassName = reader["ClassName"].ToString()!,
                CardNo = reader["CardNo"].ToString()!,
                StudentIdNo = reader["StudentIdNo"].ToString()!,
                PhoneNumber = reader["PhoneNumber"].ToString()!,
                StudentAddress = reader["StudentAddress"].ToString()!,
                StuImage = reader["StuImage"].ToString() ?? string.Empty
            };
        }

        reader.Close();
        return objStudent;
    }

    #endregion

    #region 修改学员信息

    /// <summary>
    /// 修改学员时判断身份证号是否和其他学员的重复
    /// </summary>
    public bool IsIdNoExisted(string idNo, string studentId)
    {
        string sql = $"select count(*) from Student where StudentIdNo={idNo} and StudentId<>{studentId}";
        int result = Convert.ToInt32(SQLiteHelper.GetSingleResult(sql));
        return result == 1;
    }

    /// <summary>
    /// 修改学员对象
    /// </summary>
    public int ModifyStudent(Student objStudent)
    {
        //【1】编写SQL语句
        StringBuilder sqlBuilder = new StringBuilder();
        sqlBuilder.Append("update Student set studentName='{0}',Gender='{1}',Birthday='{2}',");
        sqlBuilder.Append("StudentIdNo={3},Age={4},PhoneNumber='{5}',StudentAddress='{6}',CardNo='{7}',ClassId={8},StuImage='{9}'");
        sqlBuilder.Append(" where StudentId={10}");
        //【2】解析对象
        string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
            objStudent.Gender, objStudent.Birthday.ToString("yyyy-MM-dd"),
            objStudent.StudentIdNo, objStudent.Age,
            objStudent.PhoneNumber, objStudent.StudentAddress, objStudent.CardNo,
            objStudent.ClassId, objStudent.StuImage, objStudent.StudentId);
        try
        {
            //【3】执行SQL语句，返回结果
            return Convert.ToInt32(SQLiteHelper.Update(sql));
        }
        catch (SqlException ex)
        {
            throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
        }
    }

    #endregion

    #region 删除学员对象

    public int DeleteStudentById(string studentId)
    {
        string sql = $"delete from Student where StudentId={studentId}";
        try
        {
            return SQLiteHelper.Update(sql);
        }
        catch (SqlException ex)
        {
            if (ex.Number == 547) throw new Exception("该学号被其他实体引用，不能直接删除该学员对象！");
            throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
        }
    }

    #endregion

    /// <summary>
    /// 基于事务保存所有对象
    /// </summary>
    /// <param name="studentList">包含添加、修改、删除和查询出来的对象</param>
    public bool SaveStudents(List<StudentExt> studentList)
    {
        StringBuilder insertSql = new StringBuilder();
        insertSql.Append("insert into Student(studentName,Gender,Birthday,");
        insertSql.Append("StudentIdNo,Age,PhoneNumber,StudentAddress,CardNo,ClassId,StuImage)");
        insertSql.Append(" values('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8},'{9}');");

        StringBuilder updateSql = new StringBuilder();
        updateSql.Append("update Student set studentName='{0}',Gender='{1}',Birthday='{2}',");
        updateSql.Append("StudentIdNo={3},Age={4},PhoneNumber='{5}',StudentAddress='{6}',CardNo='{7}',ClassId={8},StuImage='{9}'");
        updateSql.Append(" where StudentId={10}");

        String deleteSql = "delete from Student where StudentId={0}";

        List<String> sqlList = new List<string>();
        foreach (StudentExt s in studentList)
        {
            if (s.OperateStatus == OperateStatus.Insert)
            {
                string sql = string.Format(insertSql.ToString(), s.StudentName, s.Gender, s.Birthday.ToString("yyyy-MM-dd"),
                    s.StudentIdNo, s.Age, s.PhoneNumber, s.StudentAddress, s.CardNo, s.ClassId, s.StuImage);
                sqlList.Add(sql);
            }

            if (s.OperateStatus == OperateStatus.Update)
            {
                string sql = string.Format(updateSql.ToString(), s.StudentName, s.Gender, s.Birthday.ToString("yyyy-MM-dd"),
                    s.StudentIdNo, s.Age, s.PhoneNumber, s.StudentAddress, s.CardNo, s.ClassId, s.StuImage, s.StudentId);
                sqlList.Add(sql);
            }

            if (s.OperateStatus == OperateStatus.Delete)
            {
                string sql = string.Format(deleteSql, s.StudentId);
                sqlList.Add(sql);
            }
        }

        return SQLiteHelper.UpdateByTran(sqlList);
    }
}
