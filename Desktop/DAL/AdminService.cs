using System.Data.SQLite;
using DAL.Helper;
using Models;

namespace DAL;

/// <summary>
/// 管理员服务类
/// </summary>
public class AdminService
{
    /// <summary>
    /// 根据用户账号和密码登录
    /// </summary>
    public Admin? AdminLogin(Admin? admin)
    {
        string sql = $"select LoginId,LoginPwd,AdminName from Admin where loginId={admin.LoginId} and loginPwd={admin.LoginPwd}";
        try
        {
            using SQLiteDataReader reader = SQLiteHelper.GetReader(sql);
            if (reader.Read())
            {
                admin.AdminName = reader["AdminName"].ToString()!;
            }
            else
            {
                admin = null;
            }
        }
        catch (SQLiteException ex)
        {
            throw new Exception("应用程序和数据库连接出现问题！", ex);
        }
        return admin;
    }

    /// <summary>
    /// 修改管理员密码
    /// </summary>
    public int ModifyPwd(Admin admin)
    {
        string sql = $"update Admin set LoginPwd={admin.LoginPwd} where LoginId={admin.LoginId}";
        try
        {
            return SQLiteHelper.Update(sql);
        }
        catch (SQLiteException ex)
        {
            throw new Exception("应用程序和数据库连接出现问题！", ex);
        }
    }
}
