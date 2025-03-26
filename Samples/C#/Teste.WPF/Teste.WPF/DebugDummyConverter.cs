using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Teste.WPF
{
    public class DebugDummyConverter : IValueConverter
    {
        // Este conversor serve apenas para depuração de Bindings válidas
        // Bindings com erros não chegam a cair neste conversor;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debugger.Break();
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debugger.Break();
            return value;
        }
    }
}
