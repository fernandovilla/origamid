using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms.Design;

namespace AgendaBolo.UI.Windows.Forms.Designer
{

    public class TextBoxFormatEditor : UITypeEditor
    {
        private static string none = "(none)";

        private IWindowsFormsEditorService formsEditorService;

        private class ListBoxItem
        {
            private TextBoxFormat format;
            private string description;

            public TextBoxFormat Format
            {
                get
                {
                    return this.format;
                }
            }

            public string Description
            {
                get
                {
                    return this.description;
                }
            }

            public override string ToString()
            {
                return this.description;
            }

            public ListBoxItem(TextBoxFormat format, string description)
            {
                this.format = format;
                this.description = description;
            }
        }

        

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context == null) || (provider == null) || (context.Instance == null))
            {
                return base.EditValue(context, provider, value);
            }

            ListBox listBox = new ListBox();
            listBox.BorderStyle = BorderStyle.None;
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.IntegralHeight = false;
            listBox.Sorted = true;
            listBox.ItemHeight = 18;
            listBox.Click += this.ListBox_Click;
            listBox.DrawItem += this.ListBox_DrawItem;


            int index = listBox.Items.Add(new ListBoxItem(null, none));

            ListBoxItem selectedItem = (ListBoxItem)listBox.Items[index];

            IEnumerable<TextBoxFormat> formatters = TextBoxFormatEditor.GetTextBoxFormatInstances(provider);

            foreach (TextBoxFormat format in formatters)
            {
                string description = format.Name ?? format.ToString();

                index = listBox.Items.Add(new ListBoxItem(format, description));

                if (value != null && value.GetType() == format.GetType())
                {
                    selectedItem = (ListBoxItem)listBox.Items[index];
                }
            }

            listBox.Height = listBox.ItemHeight * Math.Min(listBox.Items.Count, 8);
            listBox.SelectedItem = selectedItem;


            this.formsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            this.formsEditorService.DropDownControl(listBox);

            selectedItem = (ListBoxItem)listBox.SelectedItem;

            if (selectedItem == null || selectedItem.Format == null)
            {
                return null;
            }

            if (value != null && value.GetType() == selectedItem.Format.GetType())
            {
                return value;
            }

            TextBoxFormat result = selectedItem.Format;

            if (value != null && value is TextBoxFormat)
            {
                TextBoxFormat source = (TextBoxFormat)value;

                TextBoxFormatEditor.CopyTextBoxFormatProperties(result, source);
            }

            return result;
        }

        private void ListBox_Click(object sender, EventArgs e)
        {
            if (this.formsEditorService != null)
            {
                this.formsEditorService.CloseDropDown();
            }
        }

        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox box = (ListBox)sender;

            ListBoxItem item = (ListBoxItem)box.Items[e.Index];
            TextBoxFormat format = item.Format;

            e.DrawBackground();

            Rectangle bounds = e.Bounds;

            e.Graphics.FillRectangle(SystemBrushes.Window, new Rectangle(bounds.X + 2, bounds.Y + 1, 19, bounds.Height - 3));

            this.PaintValue(format, e.Graphics, new Rectangle(bounds.X + 2, bounds.Y + 1, 20, bounds.Height - 2));

            e.Graphics.DrawRectangle(SystemPens.WindowText, new Rectangle(bounds.X + 2, bounds.Y + 1, 19, bounds.Height - 3));

            using (Brush brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(item.Description, box.Font, brush, bounds.X + 26, bounds.Y);
            }
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            if (e.Value is TextBoxFormat)
            {
                Image image = null;

                AttributeCollection attributes = TypeDescriptor.GetAttributes(e.Value);
                ToolboxBitmapAttribute attribute = (ToolboxBitmapAttribute)attributes[typeof(ToolboxBitmapAttribute)];

                if (attribute != null)
                {
                    image = attribute.GetImage(e.Value, false);
                }

                if (image != null)
                {
                    Rectangle bounds = e.Bounds;

                    int x = bounds.X + ((bounds.Width - image.Width) / 2);
                    int y = bounds.Y + ((bounds.Height - image.Height) / 2);

                    e.Graphics.DrawImageUnscaled(image, x, y);
                }
            }
        }


        private static IEnumerable<Type> GetTextBoxFormatTypes(IServiceProvider provider)
        {
            ITypeDiscoveryService service = (ITypeDiscoveryService)provider.GetService(typeof(ITypeDiscoveryService));

            if (service != null)
            {
                ICollection types = service.GetTypes(typeof(TextBoxFormat), false);

                foreach (Type type in types)
                {
                    if (type.IsInterface || type.IsAbstract || type.ContainsGenericParameters || type.IsNestedPrivate) continue;

                    yield return type;
                }
            }
        }

        private static IEnumerable<TextBoxFormat> GetTextBoxFormatInstances(IServiceProvider provider)
        {
            foreach (Type type in TextBoxFormatEditor.GetTextBoxFormatTypes(provider))
            {
                TextBoxFormat format = (TextBoxFormat)Activator.CreateInstance(type);

                yield return format;
            }
        }

        private static void CopyTextBoxFormatProperties(TextBoxFormat dest, TextBoxFormat source)
        {
            Type sourceType = source.GetType();
            Type destType = dest.GetType();

            Type parent = TextBoxFormatEditor.GetLowestCommonAncestor(destType, sourceType);

            if (parent == null) return;

            PropertyInfo[] properties = parent.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (PropertyInfo property in properties)
            {
                if (!property.CanRead || !property.CanWrite) continue;

                object value = property.GetValue(source, null);

                property.SetValue(dest, value, null);
            }
        }

        private static Type GetLowestCommonAncestor(Type left, Type right)
        {
            List<Type> path = new List<Type>();

            Type root = typeof(object);



            Type node = left;

            do
            {
                path.Add(node);

                node = node.BaseType;
            }
            while (node != root);



            node = right;

            do
            {
                if (path.Contains(node)) return node;

                node = node.BaseType;
            }
            while (node != root);



            return null;
        }

    }
}
