using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design.Behavior;
using System.Windows.Forms.Design;

namespace AgendaBolo.UI.Windows.Forms.Designer
{
    public class TextBoxFormatDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;
        private char passwordChar;


        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (this.actionLists == null)
                {
                    this.actionLists = new DesignerActionListCollection();
                    this.actionLists.Add(new TextBoxFormatActionList(this));
                }

                return this.actionLists;
            }
        }

        private char PasswordChar
        {
            get
            {
                TextBoxString control = this.Control as TextBoxString;
                if (control.UseSystemPasswordChar)
                {
                    return this.passwordChar;
                }

                return control.PasswordChar;
            }
            set
            {
                TextBoxString control = this.Control as TextBoxString;
                this.passwordChar = value;
                control.PasswordChar = value;
            }
        }

        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules selectionRules = base.SelectionRules | SelectionRules.AllSizeable;

                object component = base.Component;

                PropertyDescriptor multilineProperty = TypeDescriptor.GetProperties(component)["Multiline"];
                if (multilineProperty != null && multilineProperty.GetValue(component) is bool multiline && !multiline)
                {
                    PropertyDescriptor autoSizeProperty = TypeDescriptor.GetProperties(component)["AutoSize"];
                    if (autoSizeProperty != null && autoSizeProperty.GetValue(component) is bool autoSize && autoSize)
                    {
                        selectionRules &= ~(SelectionRules.BottomSizeable | SelectionRules.TopSizeable);
                    }
                }

                return selectionRules;
            }
        }

        public override IList SnapLines
        {
            get
            {
                ArrayList snapLines = base.SnapLines as ArrayList;

                int textBaseline = DesignerUtils.GetTextBaseline(this.Control, ContentAlignment.TopLeft);
                BorderStyle style = BorderStyle.Fixed3D;

                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(base.Component)["BorderStyle"];
                if (descriptor != null)
                {
                    style = (BorderStyle)descriptor.GetValue(base.Component);
                }

                if (style == BorderStyle.FixedSingle)
                {
                    textBaseline += 2;
                }
                else if (style == BorderStyle.Fixed3D)
                {
                    textBaseline += 3;
                }

                snapLines.Add(new SnapLine(SnapLineType.Baseline, textBaseline, SnapLinePriority.Medium));

                return snapLines;
            }
        }

        private string Text
        {
            get
            {
                return this.Control.Text;
            }
            set
            {
                this.Control.Text = value;
                ((System.Windows.Forms.TextBoxBase)this.Control).Select(0, 0);
            }
        }


        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);

            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(base.Component)["Text"];
            if (descriptor != null && descriptor.PropertyType == typeof(string) && !descriptor.IsReadOnly && descriptor.IsBrowsable)
            {
                descriptor.SetValue(base.Component, "");
            }
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);

            string[] strArray = new string[] { "Text", "PasswordChar" };
            Attribute[] attributes = new Attribute[0];

            for (int i = 0; i < strArray.Length; i++)
            {
                PropertyDescriptor oldPropertyDescriptor = (PropertyDescriptor)properties[strArray[i]];
                if (oldPropertyDescriptor != null)
                {
                    properties[strArray[i]] = TypeDescriptor.CreateProperty(typeof(TextBoxFormatDesigner), oldPropertyDescriptor, attributes);
                }
            }
        }

        private void ResetText()
        {
            this.Control.Text = "";
        }

        private bool ShouldSerializeText()
        {
            return TypeDescriptor.GetProperties(typeof(System.Windows.Forms.TextBoxBase))["Text"].ShouldSerializeValue(base.Component);
        }

        public TextBoxFormatDesigner()
        {
            base.AutoResizeHandles = true;
        }

    }
}
