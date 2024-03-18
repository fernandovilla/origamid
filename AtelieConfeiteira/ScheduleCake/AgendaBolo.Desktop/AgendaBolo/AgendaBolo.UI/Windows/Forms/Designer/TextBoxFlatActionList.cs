using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.UI.Windows.Forms.Designer
{
    public class TextBoxFlatActionList : DesignerActionList
    {

        //public TextBoxFlat.SpeedButtonCollection Buttons
        //{
        //    get
        //    {
        //        return ((TextBoxFlat)base.Component).Buttons;
        //    }
        //}

        public bool Multiline
        {
            get
            {
                return ((TextBox)base.Component).Multiline;
            }
            set
            {
                TypeDescriptor.GetProperties(base.Component)["Multiline"].SetValue(base.Component, value);
            }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            items.Add(new DesignerActionPropertyItem("Multiline", "MultiLine", "Properties", "Puts the TextBox in a mode where it can display multiple lines of text"));
            items.Add(new DesignerActionPropertyItem("Buttons", "Edit Buttons"));

            return items;
        }

        public TextBoxFlatActionList(TextBoxFlatDesigner designer)
            : base(designer.Component)
        {
        }
    }
}
