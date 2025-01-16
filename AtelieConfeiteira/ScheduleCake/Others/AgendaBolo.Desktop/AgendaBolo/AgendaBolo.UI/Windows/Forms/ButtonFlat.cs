using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.UI.Windows.Forms
{
    public class ButtonFlat : System.Windows.Forms.Button
    {        
        public ButtonFlat()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = Const.BORDER_COLOR;
            FlatAppearance.BorderSize = 1;

            Size = new Size(120, 30);

            this.Font = new Font(Const.FONT_FAMILY, Const.FONT_SIZE_BUTTON, FontStyle.Regular);
        }

    }
}
