using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace DAL.Helper;

/// <summary>
/// Sqlite 数据访问类
/// </summary>
public class SQLiteHelper
{
    private static readonly string DbPath = ConfigurationManager.ConnectionStrings["dbPath"].ToString();
    private static readonly string ConnString = $"Data Source={DbPath}";

    /// <summary>
    /// 执行增、删、改（insert/update/delete）
    /// </summary>
    public static int Update(string sql)
    {
        SQLiteConnection conn = new SQLiteConnection(ConnString);
        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
        try
        {
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }
    }

    /// <summary>
    /// 执行单一结果查询（select）
    /// </summary>
    public static object GetSingleResult(string sql)
    {
        SQLiteConnection conn = new SQLiteConnection(ConnString);
        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
        try
        {
            conn.Open();
            return cmd.ExecuteScalar() ?? throw new InvalidOperationException();
        }
        finally
        {
            conn.Close();
        }
    }

    /// <summary>
    /// 执行多结果查询（select）
    /// </summary>
    public static SQLiteDataReader GetReader(string sql)
    {
        SQLiteConnection conn = new SQLiteConnection(ConnString);
        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
        try
        {
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
            conn.Close();
            throw;
        }
    }

    /// <summary>
    /// 执行返回数据集的查询
    /// </summary>
    public static DataSet GetDataSet(string sql)
    {
        SQLiteConnection conn = new SQLiteConnection(ConnString);
        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd);
        DataSet dataSet = new DataSet();
        try
        {
            conn.Open();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }
        finally
        {
            conn.Close();
        }
    }

    /// <summary>
    /// 启用事务执行多条SQL语句
    /// </summary>
    public static bool UpdateByTran(List<string> sqlList)
    {
        SQLiteConnection conn = new SQLiteConnection(ConnString);
        SQLiteCommand cmd = new SQLiteCommand();
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
            conn.Close();
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
