using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Windows;
using DAL.Helper;

namespace WPF;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        SQLiteHelper.InitializeDatabase();
    }
}
