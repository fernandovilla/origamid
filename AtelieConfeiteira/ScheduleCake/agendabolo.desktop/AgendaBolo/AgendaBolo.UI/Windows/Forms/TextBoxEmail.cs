using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.UI.Windows.Forms
{
    [ToolboxBitmap(typeof(TextBox))]
    internal class TextBoxEmail: TextBoxFormatBase
    {        
        public TextBoxEmail()
        {
            this.Format = new TextBoxTypeFormatEmail();
        }
    }
}
