using System.Data;
using System.Data.OleDb;
using System.Runtime.Versioning;

namespace DAL.Helper;

/// <summary>
/// OLE DB 数据源访问
/// </summary>
[SupportedOSPlatform("windows")]
public static class OleDbHelper
{
    // 适合 Excel 2003 版本
    // private const string ConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0";
    // 适合 Excel 2007 以后的版本
    private const string ConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0";

    /// <summary>
    /// 执行增、删、改（insert/update/delete）
    /// </summary>
    public static int Update(string sql)
    {
        using OleDbConnection conn = new OleDbConnection(ConnString);
        using OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        return cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// 执行单一结果查询（select）
    /// </summary>
    public static object GetSingleResult(string sql)
    {
        using OleDbConnection conn = new OleDbConnection(ConnString);
        using OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        return cmd.ExecuteScalar() ?? throw new InvalidOperationException();
    }

    /// <summary>
    /// 执行多结果查询（select）
    /// </summary>
    public static OleDbDataReader GetReader(string sql)
    {
        OleDbConnection conn = new OleDbConnection(ConnString);
        OleDbCommand cmd = new OleDbCommand(sql, conn);
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
        using OleDbConnection conn = new OleDbConnection(ConnString);
        using OleDbCommand cmd = new OleDbCommand(sql, conn);
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
        DataSet dataSet = new DataSet();
        conn.Open();
        dataAdapter.Fill(dataSet);
        return dataSet;
    }

    /// <summary>
    /// 读取数据到 DataSet 中
    /// </summary>
    public static DataSet GetDataSet(string sql, string path)
    {
        using OleDbConnection conn = new OleDbConnection(string.Format(ConnString, path));
        using OleDbCommand cmd = new OleDbCommand(sql, conn);
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
        DataSet dataSet = new DataSet();
        conn.Open();
        dataAdapter.Fill(dataSet);
        return dataSet;
    }
}
