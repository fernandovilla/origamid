using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace AgendaBolo.UI.Windows.Forms
{
    [ToolboxBitmap(typeof(TextBox))]
    public class TextBoxString: TextBoxFormatBase
    {
        public TextBoxString()
        {
            Format = new TextBoxTypeFormatText();
        }
    }
}
