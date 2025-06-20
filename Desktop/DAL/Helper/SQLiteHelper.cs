using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace DAL.Helper;

/// <summary>
/// Sqlite 数据访问类
/// </summary>
public class SQLiteHelper
{
    private static readonly string ConnString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

    /// <summary>
    /// 执行增、删、改（insert/update/delete）
    /// </summary>
    public static int Update(string sql)
    {
        using SQLiteConnection conn = new SQLiteConnection(ConnString);
        conn.Open();
        using SQLiteCommand cmd = new SQLiteCommand(sql, conn);
        return cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// 执行单一结果查询（select）
    /// </summary>
    public static object GetSingleResult(string sql)
    {
        using SQLiteConnection conn = new SQLiteConnection(ConnString);
        conn.Open();
        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
        return cmd.ExecuteScalar() ?? throw new InvalidOperationException();
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
        using SQLiteConnection conn = new SQLiteConnection(ConnString);
        conn.Open();
        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd);
        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);
        return dataSet;
    }

    /// <summary>
    /// 启用事务执行多条SQL语句
    /// </summary>
    public static bool UpdateByTran(List<string> sqlList)
    {
        using SQLiteConnection conn = new SQLiteConnection(ConnString);
        conn.Open();
        using SQLiteCommand cmd = new SQLiteCommand();
        cmd.Connection = conn;
        try
        {
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

    /// <summary>
    /// 初始化数据库和表
    /// </summary>
    public static void InitializeDatabase()
    {
        // 如果数据库不存在，则创建数据库和表
        string dbPath = ConnString.Split("=")[1];
        if (File.Exists(dbPath)) return;

        using var connection = new SQLiteConnection(ConnString);
        connection.Open();

        const string createStudentTableSql = """
                                             create table if not exists Student
                                                 (
                                                     StudentId integer primary key autoincrement,
                                                     StudentName text not null,
                                                     Gender text not null check (Gender in ('男', '女')),
                                                     Birthday text not null,
                                                     StudentIdNo text not null unique,
                                                     CardNo text not null unique,
                                                     StuImage text null,
                                                     Age integer not null check (Age between 18 and 35),
                                                     PhoneNumber text,
                                                     StudentAddress text default '地址不详',
                                                     ClassId integer not null,
                                                     foreign key (ClassId) references StudentClass(ClassId)
                                                 );
                                             """;

        const string createStudentClassTableSql = """
                                                  create table if not exists StudentClass
                                                      (
                                                  	    ClassId integer primary key autoincrement,
                                                          ClassName text not null
                                                      );
                                                  """;

        const string createScoreListTableSql = """
                                               create table if not exists ScoreList
                                                   (
                                                       Id integer primary key autoincrement,
                                                       StudentId integer not null,
                                                       CSharp integer null,
                                                       SQLServerDB integer null,
                                                       UpdateTime text null,
                                                       foreign key (StudentId) references Student(StudentId)
                                                   );
                                               """;

        const string createAttendanceTableSql = """
                                                create table if not exists Attendance
                                                    (
                                                	    Id integer primary key autoincrement,
                                                        CardNo text not null,
                                                        DTime text null
                                                    );
                                                """;

        const string createAdminTableSql = """
                                     create table if not exists Admin
                                         (
                                     	    LoginId integer primary key autoincrement,
                                             LoginPwd text not null,
                                             AdminName text not null
                                         );
                                     """;

        const string insertStudentClassSql = """
                                             insert into StudentClass(ClassId,ClassName) values(1,'软件1班');
                                             insert into StudentClass(ClassId,ClassName) values(2,'软件2班');
                                             insert into StudentClass(ClassId,ClassName) values(3,'计算机1班');
                                             insert into StudentClass(ClassId,ClassName) values(4,'计算机2班');
                                             insert into StudentClass(ClassId,ClassName) values(5,'网络1班');
                                             insert into StudentClass(ClassId,ClassName) values(6,'网络2班');
                                             """;

        const string insertStudentSql = """
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                 values('王小虎','男','1989-08-07',22,120223198908071111,'0004018766','022-22222222','天津市南开区红磡公寓5-5-102',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                 values('贺小张','女','1989-05-06',22,120223198905062426,'0006394426','022-33333333','天津市河北区王串场58号',2);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                 values('马小李','男','1990-02-07',21,120223199002078915,'0006073516','022-44444444','天津市红桥区丁字沽曙光路79号',4);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                 values('冯小强','女','1987-05-12',24,130223198705125167,'0006254540','022-55555555','地址不详',2);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                 values('杜小丽','女','1986-05-08',25,130223198605081528,'0006403803','022-66666666','河北衡水路北道69号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                 values('王俊桥','男','1987-07-18',24,130223198707182235,'0006404372','022-77777777','地址不详',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                 values('张永利','男','1988-09-28',24,130223198909282235,'0006092947','022-88888888','河北保定市风华道12号',3);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                 values('李铭','男','1987-01-18',24,130223198701182257,'0006294564','022-99999999','河北邢台市幸福路5号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                 values('宁俊燕','女','1987-06-15',24,130223198706152211,'0006092450','022-11111111','地址不详',3);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                 values('刘玲玲','女','1989-08-19',24,130223198908192235,'0006069457','022-11111222','地址不详',4);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                values('王小军','女','1986-05-08',25,130224198605081528,'0006403820','022-66666666','河北衡水路北道69号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                values('刘小丽','女','1986-05-08',25,130225198605081528,'0006403821','022-66666666','河北衡水路北道69号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                values('张慧鑫','女','1986-05-08',25,130226198605081528,'0006403822','022-66666666','河北衡水路北道69号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                values('李素云','女','1986-05-08',25,130227198605081528,'0006403823','022-66666666','河北衡水路北道69号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                values('赵小金','女','1986-05-08',25,130228198605081528,'0006403824','022-66666666','河北衡水路北道69号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                values('王浩宇','男','1986-05-08',25,130229198605081528,'0006403825','022-66666666','河北衡水路北道69号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                values('崔永鑫','女','1986-05-08',25,130222198605081528,'0006403826','022-66666666','河北衡水路北道69号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                values('包丽云','女','1986-05-08',25,130220198605081528,'0006403827','022-66666666','河北衡水路北道69号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                values('孙丽媛','女','1986-05-08',25,130228198605081530,'0006403854','022-66666666','河北衡水路北道69号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                values('郝志云','男','1986-05-08',25,130229198605081531,'0006403855','022-66666666','河北衡水路北道69号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                values('王保华','女','1986-05-08',25,130222198605081532,'0006403856','022-66666666','河北衡水路北道69号',1);
                                        insert into Student (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)
                                                values('李丽颖','女','1986-05-08',25,130220198605081544,'0006403857','022-66666666','河北衡水路北道69号',1);
                                        """;

        const string insertScoreListSql = """
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100000,60,78);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100001,55,88);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100002,90,58);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100003,88,75);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100004,62,88);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100006,52,80);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100007,91,66);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100009,78,35);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100000,60,78);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100001,55,88);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100002,90,58);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100003,88,75);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100004,62,88);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100006,52,80);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100007,91,66);
                                          insert into ScoreList (StudentId,CSharp,SQLServerDB)values(100009,78,35);
                                          """;

        const string insertAdminSql = """
                                      insert into Admin (LoginPwd,AdminName) values(123456,'王晓军');
                                      insert into Admin (LoginPwd,AdminName) values(123456,'张明丽');
                                      """;

        using var command = new SQLiteCommand(
            createStudentTableSql + createStudentClassTableSql + createScoreListTableSql + createAttendanceTableSql + createAdminTableSql
            + insertStudentClassSql + insertStudentSql + insertScoreListSql + insertAdminSql
            , connection);
        command.ExecuteNonQuery();
    }
}
