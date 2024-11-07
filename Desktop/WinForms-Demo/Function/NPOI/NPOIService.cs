using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Reflection;
using BorderStyle = NPOI.SS.UserModel.BorderStyle;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;

namespace WinForms_Demo.Function.NPOI;
public class NPOIService
{
    /// <summary>
    /// 将泛型集合中的实体导出到指定的Excel文件
    /// </summary>
    /// <param name="fileName">Excel路径和文件名</param>
    /// <param name="dataList">泛型集合</param>
    /// <param name="columnNames">标题集合</param>
    /// <param name="version">Excel版本号，0：2007以前</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool ExportToExcel<T>(string fileName, List<T> dataList, Dictionary<string, string> columnNames, int version = 0) where T : class
    {
        IWorkbook workbook = version == 0 ? new HSSFWorkbook() : new XSSFWorkbook();
        ISheet sheet = workbook.CreateSheet("sheet1");
        Type type = typeof(T);
        PropertyInfo[] propertyinfos = type.GetProperties();

        // 标题
        IRow headerRow = sheet.CreateRow(0);
        for (int i = 0; i < propertyinfos.Length; i++)
        {
            ICell cell = headerRow.CreateCell(i);
            cell.SetCellValue(columnNames[propertyinfos[i].Name]);
            SetCellStyle(workbook, cell);
            SetColumnWith(sheet, i, 20);
        }

        // 数据
        for (int i = 0; i < dataList.Count; i++)
        {
            IRow row = sheet.CreateRow(i + 1);
            T model = dataList[i];
            for (int j = 0; j < propertyinfos.Length; j++)
            {
                ICell cell = row.CreateCell(j);
                string value = propertyinfos[j].GetValue(model, null).ToString();
                cell.SetCellValue(value);
                SetCellStyle(workbook, cell);
            }
        }

        using FileStream fs = File.OpenWrite(fileName);
        workbook.Write(fs);
        return true;
    }

    private static void SetCellStyle(IWorkbook workbook, ICell cell)
    {
        IFont font = workbook.CreateFont();
        font.FontName = "微软雅黑";
        font.FontHeight = 15 * 15;
        font.Color = IndexedColors.Green.Index;

        ICellStyle style = workbook.CreateCellStyle();
        style.SetFont(font);
        style.BorderBottom = BorderStyle.Thin;
        style.BorderLeft = BorderStyle.Thin;
        style.BorderRight = BorderStyle.Thin;
        style.BorderTop = BorderStyle.Thin;
        style.Alignment = HorizontalAlignment.Center;
        style.VerticalAlignment = VerticalAlignment.Center;

        cell.CellStyle = style;
    }

    private static void SetColumnWith(ISheet sheet, int index, int width)
    {
        sheet.SetColumnWidth(index, width * 256);
    }
}
