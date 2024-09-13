using System.Data;
using System.Data.SQLite;
using DAL.Helper;
using Models;
using Models.Ext;

namespace DAL;

/// <summary>
/// 成绩服务类
/// </summary>
public class ScoreListService
{
    #region 按照班级统计考试信息

    /// <summary>
    /// 按照班级统计考试信息
    /// </summary>
    public Dictionary<string, string?>? GetScoreInfoByClassId(string? classId)
    {
        string sql = "select stuCount=count(*),avgCSharp=avg(CSharp),avgDB=avg(SQLServerDB) from ScoreList ";
        if (classId != null) sql += "inner join Student on Student.StudentId=ScoreList.StudentId where ClassId={0};";
        sql += "select absentCount=count(*) from Student where StudentId not in";
        if (classId != null)
        {
            sql += "(select StudentId from ScoreList) and ClassId={1}";
            sql = string.Format(sql, classId, classId);
        }

        SQLiteDataReader reader = SQLiteHelper.GetReader(sql);
        Dictionary<string, string?>? scoreInfo = null;
        if (reader.Read())
        {
            scoreInfo = new Dictionary<string, string?>
            {
                { "stuCount", reader["stucount"].ToString() },
                { "avgCSharp", reader["avgCSharp"].ToString() },
                { "avgDB", reader["avgDB"].ToString() }
            };
        }

        if (reader.NextResult())
        {
            if (reader.Read())
            {
                scoreInfo?.Add("absentCount", reader["absentCount"].ToString());
            }
        }

        reader.Close();
        return scoreInfo;
    }

    #endregion

    /// <summary>
    /// 根据班级 ID 查询未参加考试的学生名单
    /// </summary>
    public List<string?> GetAbsentListByClassId(string? classId)
    {
        string sql = "select StudentName from Student where StudentId not in(select StudentId from ScoreList) ";
        if (classId != null)
        {
            sql += "and ClassId={0}";
            sql = string.Format(sql, classId);
        }

        SQLiteDataReader reader = SQLiteHelper.GetReader(sql);
        List<string?> list = [];
        while (reader.Read())
        {
            list.Add(reader["StudentName"].ToString());
        }

        reader.Close();
        return list;
    }

    #region 查询考试成绩

    /// <summary>
    /// 查询考试成绩
    /// </summary>
    public List<StudentExt> GetSCoreList(string className)
    {
        string sql = "select Student.StudentId,StudentName,ClassName,Gender,PhoneNumber,CSharp,SQLServerDB from Student";
        sql += " inner join StudentClass on StudentClass.ClassId=Student.ClassId ";
        sql += " inner join ScoreList on ScoreList.StudentId=Student.StudentId ";
        if (className.Length != 0)
        {
            sql += " where ClassName='" + className + "'";
        }

        SQLiteDataReader reader = SQLiteHelper.GetReader(sql);
        List<StudentExt> list = new List<StudentExt>();
        while (reader.Read())
        {
            list.Add(new StudentExt()
            {
                StudentId = Convert.ToInt32(reader["StudentId"]),
                StudentName = reader["StudentName"].ToString()!,
                ClassName = reader["ClassName"].ToString()!,
                Gender = reader["Gender"].ToString()!,
                PhoneNumber = reader["PhoneNumber"].ToString()!,
                CSharp = reader["CSharp"].ToString()!,
                SQLServerDB = reader["SQLServerDB"].ToString()!,
                cc = false
            });
        }

        reader.Close();
        return list;
    }

    /// <summary>
    /// 查询考试成绩 V2
    /// </summary>
    public List<ExtStudent> GetScoreListV2(string className)
    {
        string sql = "select Student.StudentId,StudentName,ClassName,Gender,PhoneNumber,CSharp,SQLServerDB from Student";
        sql += " inner join StudentClass on StudentClass.ClassId=Student.ClassId ";
        sql += " inner join ScoreList on ScoreList.StudentId=Student.StudentId ";
        if (className.Length != 0)
        {
            sql += " where ClassName='" + className + "'";
        }

        SQLiteDataReader reader = SQLiteHelper.GetReader(sql);
        List<ExtStudent> list = [];
        while (reader.Read())
        {
            list.Add(new ExtStudent()
            {
                ObjStudent = new Student()
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    StudentName = reader["StudentName"].ToString()!,
                    Gender = reader["Gender"].ToString()!,
                    PhoneNumber = reader["PhoneNumber"].ToString()!,
                },
                ObjScore = new ScoreList()
                {
                    CSharp = Convert.ToInt32(reader["CSharp"]),
                    SQLServerDB = Convert.ToInt32(reader["SQLServerDB"]),
                },
                ClassName = reader["ClassName"].ToString()!,
                cc = false
            });
        }

        reader.Close();
        return list;
    }

    #endregion

    /// <summary>
    /// 获取所有的学员成绩列表
    /// </summary>
    public DataSet GetAllScoreList()
    {
        string sql = "select Student.StudentId,StudentName,ClassName,Gender,PhoneNumber,CSharp,SQLServerDB";
        sql += " from Student";
        sql += " inner join StudentClass on StudentClass.ClassId=Student.ClassId ";
        sql += " inner join ScoreList on ScoreList.StudentId=Student.StudentId ";
        return SQLiteHelper.GetDataSet(sql);
    }
}
