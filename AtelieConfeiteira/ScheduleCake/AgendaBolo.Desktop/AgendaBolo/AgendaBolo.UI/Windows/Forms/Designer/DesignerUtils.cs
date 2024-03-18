using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace AgendaBolo.UI.Windows.Forms.Designer
{
    public static class DesignerUtils
    {
        private static Type instance;
        private static MethodInfo getTextBaselineMethod;

        private static Type Instance
        {
            get
            {
                if (DesignerUtils.instance == null)
                {
                    DesignerUtils.instance = typeof(ControlDesigner).Assembly.GetType("System.Windows.Forms.Design.DesignerUtils");
                }

                return DesignerUtils.instance;
            }
        }

        private static MethodInfo GetTextBaselineMethod
        {
            get
            {
                if (DesignerUtils.getTextBaselineMethod == null && DesignerUtils.Instance != null)
                {
                    DesignerUtils.getTextBaselineMethod = DesignerUtils.Instance.GetMethod("GetTextBaseline", BindingFlags.Static | BindingFlags.Public);
                }

                return DesignerUtils.getTextBaselineMethod;
            }
        }

        public static int GetTextBaseline(Control control, ContentAlignment alignment)
        {
            return (int)DesignerUtils.GetTextBaselineMethod.Invoke(null, new object[] { control, alignment });
        }

    }
}
