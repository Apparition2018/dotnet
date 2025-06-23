using System.ComponentModel;

namespace WinForms.Function.CustomizedControl;

[ToolboxBitmap(typeof(System.Windows.Forms.ProgressBar))]
public partial class ProgressBar : UserControl
{
    public ProgressBar()
    {
        InitializeComponent();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        // 启用双缓冲，优化控件绘制性能、减少屏幕闪烁
        // 相当于 SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        DoubleBuffered = true;
        SetStyle(ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        Rectangle clientRect = ClientRectangle;

        // 1. 绘制背景
        using (var backBrush = new SolidBrush(BackColor))
        {
            g.FillRectangle(backBrush, clientRect);
        }

        // 2. 绘制进度条
        if (Percent > 0)
        {
            int progressWidth = (int)(Percent / 100.0 * clientRect.Width);
            Rectangle progressRect = new Rectangle(0, 0, progressWidth, clientRect.Height);

            using var progressBrush = new SolidBrush(ProgressColor);
            g.FillRectangle(progressBrush, progressRect);
        }

        // 3. 绘制边框
        DrawBorder(g, clientRect);

        // 4. 绘制百分比文本
        if (ShowPercentage)
        {
            DrawPercentageText(g, clientRect);
        }
    }

    private void DrawBorder(Graphics g, Rectangle rect)
    {
        switch (BorderStyle)
        {
            case ProgressBarBorderStyle.Single:
                using (var pen = new Pen(BorderColor, 1))
                {
                    g.DrawRectangle(pen, rect with { Width = rect.Width - 1, Height = rect.Height - 1 });
                }
                break;
            case ProgressBarBorderStyle.ThreeD:
                ControlPaint.DrawBorder3D(g, rect, Border3DStyle.Sunken);
                break;
            case ProgressBarBorderStyle.None:
            default:
                break;
        }
    }

    private void DrawPercentageText(Graphics g, Rectangle rect)
    {
        string text = $"{Percent}%";
        using var format = new StringFormat();
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;
        using var brush = new SolidBrush(TextColor);
        g.DrawString(text, Font, brush, rect, format);
    }

    #region 属性

    private int _percent;

    [Category("Appearance")]
    [DefaultValue(0)]
    [Description("当前进度百分比")]
    public int Percent
    {
        get => _percent;
        set
        {
            int newValue = Math.Max(0, Math.Min(100, value));
            if (_percent == newValue) return;
            _percent = newValue;
            Invalidate();
        }
    }

    private Color _progressColor = Color.Orchid;

    [Category("Appearance")]
    [Description("进度条颜色")]
    public Color ProgressColor
    {
        get => _progressColor;
        set
        {
            if (_progressColor == value) return;
            _progressColor = value;
            Invalidate();
        }
    }

    private bool _showPercentage = true;

    [Category("Appearance")]
    [DefaultValue(true)]
    [Description("是否显示百分比")]
    public bool ShowPercentage
    {
        get => _showPercentage;
        set
        {
            if (_showPercentage == value) return;
            _showPercentage = value;
            Invalidate();
        }
    }

    private Color _textColor = Color.Black;

    [Category("Appearance")]
    [Description("文本颜色")]
    public Color TextColor
    {
        get => _textColor;
        set
        {
            if (_textColor == value) return;
            _textColor = value;
            Invalidate();
        }
    }

    private Color _borderColor = SystemColors.ControlDark;

    [Category("Appearance")]
    [Description("边框颜色")]
    public Color BorderColor
    {
        get => _borderColor;
        set
        {
            if (_borderColor == value) return;
            _borderColor = value;
            Invalidate();
        }
    }

    private ProgressBarBorderStyle _borderStyle = ProgressBarBorderStyle.Single;

    [Category("Appearance")]
    [DefaultValue(ProgressBarBorderStyle.Single)]
    [Description("边框样式")]
    public new ProgressBarBorderStyle BorderStyle
    {
        get => _borderStyle;
        set
        {
            if (_borderStyle == value) return;
            _borderStyle = value;
            Invalidate();
        }
    }

    #endregion
}

public enum ProgressBarBorderStyle
{
    None,
    Single,
    ThreeD
}
