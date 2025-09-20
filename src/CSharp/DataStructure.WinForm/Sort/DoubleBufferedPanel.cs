using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataStructure.WinForm.Sort
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            // 启用双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.DoubleBuffer |
                         ControlStyles.ResizeRedraw, true);
            
            // 禁用自动重绘
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            
            // 优化绘制性能
            this.SetStyle(ControlStyles.Opaque, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // 不绘制背景，减少闪烁
            // base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 使用双缓冲绘制
            base.OnPaint(e);
        }
    }
}
