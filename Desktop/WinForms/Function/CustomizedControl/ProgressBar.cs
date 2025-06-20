using NPOI.Util;

namespace WinForms.Function.CustomizedControl;

// 新建控件
public partial class ProgressBar : UserControl
{
    public ProgressBar()
    {
        InitializeComponent();
        lblLong.Paint += percent_Paint;
    }

    private void percent_Paint(object? sender, PaintEventArgs e)
    {
        if (!IsShowPercent) return;
        string text = $"{_percent}%";
        SizeF size = e.Graphics.MeasureString(text, Font);
        float x = (lblLong.Width - size.Width) / 2;
        float y = (lblLong.Height - size.Height) / 2;
        e.Graphics.DrawString(text, Font, Brushes.Black, x, y);
    }

    /// <summary>
    /// 进度条长度
    /// </summary>
    private int _pWidth = 400;

    public int PWidth
    {
        get => _pWidth;
        set
        {
            const int minWidth = 300;
            const int maxWidth = 600;
            if (value < minWidth | value > maxWidth)
            {
                MessageBox.Show($@"长度必须在{minWidth}~{maxWidth}之间", @"提示");
                return;
            }
            _pWidth = value;
            lblShort.Width = value;
        }
    }

    /// <summary>
    /// 进度条高度
    /// </summary>
    private int _pHeight = 20;

    public int PHeight
    {
        get => _pHeight;
        set
        {
            const int minHeight = 10;
            const int maxHeight = 30;
            if (value < minHeight | value > maxHeight)
            {
                MessageBox.Show($@"高度必须在{minHeight}~{maxHeight}之间", @"提示");
                return;
            }
            _pHeight = value;
            lblLong.Height = value;
            lblShort.Height = value;
        }
    }

    /// <summary>
    /// 百分比
    /// </summary>
    private int _percent;

    public int Percent
    {
        get => _percent;
        set
        {
            const int min = 0;
            const int max = 100;
            if (value is < min or > max)
            {
                MessageBox.Show($@"百分比必须在{min}~{max}之间", @"提示");
                return;
            }
            _percent = value;
            lblShort.Width = Convert.ToInt32(_pWidth * value / 100.0);
            lblLong.Invalidate();
        }
    }

    /// <summary>
    /// 是否显示百分比
    /// </summary>
    public bool IsShowPercent { get ; set; } = true;

    /// <summary>
    /// 进度条颜色
    /// </summary>
    private Color _pColor = Color.Orchid;

    public Color PColor
    {
        get => _pColor;
        set
        {
            _pColor = value;
            lblShort.BackColor = value;
        }
    }

    /// <summary>
    /// 进度条边框样式
    /// </summary>
    private BorderStyle _pBorderStyle = BorderStyle.FixedSingle;

    public BorderStyle PBorderStyle
    {
        get => _pBorderStyle;
        set
        {
            _pBorderStyle = value;
            lblShort.BorderStyle = value;
            switch (value)
            {
                case BorderStyle.FixedSingle:
                    lblLong.BorderStyle = value;
                    break;
                case BorderStyle.Fixed3D:
                    lblShort.BorderStyle = BorderStyle.None;
                    break;
                default:
                    lblShort.BorderStyle = BorderStyle.None;
                    break;
            }
        }
    }
}
