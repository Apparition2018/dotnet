using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Helper;

/// <summary>
/// SqlServer 数据访问类
/// </summary>
public static class SqlHelper
{
    // private static readonly string connString = "Server=.;DataBase=StudentManageDB;Uid=sa;Pwd=password01!";
    private static readonly string ConnString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
    // private static readonly string connString =
    //     Common.StringSecurity.DESDecrypt(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

    /// <summary>
    /// 执行增、删、改（insert/update/delete）
    /// </summary>
    public static int Update(string sql)
    {
        using SqlConnection conn = new SqlConnection(ConnString);
        using SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        return cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// 执行单一结果查询（select）
    /// </summary>
    public static object GetSingleResult(string sql)
    {
        using SqlConnection conn = new SqlConnection(ConnString);
        using SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        return cmd.ExecuteScalar() ?? throw new InvalidOperationException();
    }

    /// <summary>
    /// 执行多结果查询（select）
    /// </summary>
    public static SqlDataReader GetReader(string sql)
    {
        SqlConnection conn = new SqlConnection(ConnString);
        SqlCommand cmd = new SqlCommand(sql, conn);
        try
        {
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            cmd.Dispose();
            throw;
        }
    }

    /// <summary>
    /// 执行返回数据集的查询
    /// </summary>
    public static DataSet GetDataSet(string sql)
    {
        using SqlConnection conn = new SqlConnection(ConnString);
        using SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        DataSet dataSet = new DataSet();
        conn.Open();
        dataAdapter.Fill(dataSet);
        return dataSet;
    }

    /// <summary>
    /// 启用事务执行多条SQL语句
    /// </summary>
    public static bool UpdateByTran(List<string> sqlList)
    {
        using SqlConnection conn = new SqlConnection(ConnString);
        using SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        try
        {
            conn.Open();
            cmd.Transaction = conn.BeginTransaction();
            foreach (string itemSql in sqlList)
            {
                cmd.CommandText = itemSql;
                cmd.ExecuteNonQuery();
            }

            cmd.Transaction.Commit();
            return true;
        }
        catch (Exception ex)
        {
            cmd.Transaction?.Rollback();
            throw new Exception("调用事务方法 UpdateByTran 时出现错误：" + ex.Message, ex);
        }
        finally
        {
            cmd.Transaction = null;
        }
    }

    /// <summary>
    /// 获取服务器的时间
    /// </summary>
    public static DateTime GetServerTime()
    {
        return Convert.ToDateTime(GetSingleResult("select getdate()"));
    }
}
