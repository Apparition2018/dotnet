using System.Data;

namespace DAL.Helper;

public class Page
{
    /// <summary>每页条数</summary>
    public int PageSize { get; set; }
    /// <summary>显示字段（以逗号分隔）</summary>
    public string FiledName { get; set; }
    /// <summary>表名</summary>
    public string TableName { get; set; }
    /// <summary>查询条件</summary>
    public string Condition { get; set; }
    /// <summary>当前页码</summary>
    public int PageNum { get; set; }
    /// <summary>排序条件</summary>
    public string Sort { get; set; }
    /// <summary>总数</summary>
    private int totalCount;
    public int TotalCount => totalCount;
    /// <summary>总页数</summary>
    public int TotalPage
    {
        get
        {
            if (totalCount == 0)
            {
                PageNum = 1;
                return 0;
            }
            if (totalCount % PageSize != 0)
            {
                return totalCount / PageSize + 1;
            }
            return totalCount / PageSize;
        }
    }

    /// <summary>
    /// 分页SQL
    /// </summary>
    private string GetSql()
    {
        string offset = (PageSize * (PageNum - 1)).ToString();
        string sql = "select {0} from {1} where {2} order by {3} limit {4}, {5};";
        sql += "select count(*) from {6} where {7}";
        return string.Format(sql, FiledName, TableName, Condition, Sort, offset, PageSize, TableName, Condition);
    }

    /// <summary>
    /// 分页数据
    /// </summary>
    public DataTable GetData()
    {
        Console.WriteLine(GetSql());
        DataSet dataSet = SQLiteHelper.GetDataSet(GetSql());
        totalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]);
        return dataSet.Tables[0];
    }
}
