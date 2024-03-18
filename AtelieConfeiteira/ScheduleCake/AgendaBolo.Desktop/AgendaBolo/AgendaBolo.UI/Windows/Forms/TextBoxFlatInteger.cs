using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.UI.Windows.Forms
{
    public class TextBoxFlatInteger: TextBoxFlat
    {
        public TextBoxFlatInteger()
        {
            Format = new TextBoxFormatInteger();
        }
    }
}
