using AgendaBolo.UI.Windows.Forms.Designer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.UI.Windows.Forms
{
    [DebuggerNonUserCode(), ToolboxBitmap(typeof(TextBox)), Designer(typeof(TextBoxFlatDesigner))]
    public class TextBoxFlat: TextBox
    {
        private TextBoxFormat format;


        public event EventHandler FormatChanged;


        [DefaultValue(null)]
        [Editor(typeof(TextBoxFormatEditor), typeof(UITypeEditor))]
        public TextBoxFormat Format
        {
            get
            {
                return this.format;
            }
            set
            {
                if (this.format != value)
                {
                    if (this.format != null)
                    {
                        this.format.Release(this);
                    }

                    this.format = value;

                    if (this.format != null)
                    {
                        this.format.Assign(this);
                    }

                    this.OnFormatChanged(EventArgs.Empty);
                }
            }
        }

        protected virtual void OnFormatChanged(EventArgs e)
        {
            this.FormatChanged?.Invoke(this, e);
        }
    }
}
