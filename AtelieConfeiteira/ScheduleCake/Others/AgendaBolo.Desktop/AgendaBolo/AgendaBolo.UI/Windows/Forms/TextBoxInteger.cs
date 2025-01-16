using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.UI.Windows.Forms
{
    [ToolboxItem(true), ToolboxBitmap(typeof(TextBox))]
    public class TextBoxInteger: TextBoxFormatBase
    {
        public TextBoxInteger()
        {
            Format = new TextBoxTypeFormatInteger();
        }
    }
}
