using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AgendaBolo.UI.Windows.Forms
{
    public class Group : System.Windows.Forms.ContainerControl
    {
        private Padding _padding = new Padding(1);

        protected override Padding DefaultPadding => _padding;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color backColor = this.BackColor;
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle(0, 0, this.Width - 1, this.Height - 1));


            using (Brush brush = new SolidBrush(backColor))
                e.Graphics.FillPath(brush, path);

            Color borderColor = Const.BORDER_COLOR;
            float borderWidth = 1;

            using (Pen pen = new Pen(borderColor, borderWidth))
                e.Graphics.DrawPath(pen, path);
        }


    }
}
