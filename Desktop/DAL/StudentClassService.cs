using System.Data;
using System.Data.SQLite;
using DAL.Helper;
using Models;

namespace DAL;

/// <summary>
/// 学员服务类
/// </summary>
public class StudentClassService
{
    public List<StudentClass> GetAllClasses()
    {
        string sql = "select className,classId from StudentClass";
        using SQLiteDataReader reader = SQLiteHelper.GetReader(sql);
        List<StudentClass> list = [];
        while (reader.Read())
        {
            list.Add(new StudentClass
            {
                ClassId = Convert.ToInt32(reader["ClassId"]),
                ClassName = reader["ClassName"].ToString()!
            });
        }
        return list;
    }

    /// <summary>
    /// 获取所有的班级（存放在数据集里面）
    /// </summary>
    public DataSet GetAllClass()
    {
        string sql = "select ClassId,ClassName from StudentClass";
        return SQLiteHelper.GetDataSet(sql);
    }
}
