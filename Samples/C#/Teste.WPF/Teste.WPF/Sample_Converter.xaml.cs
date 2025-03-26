using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Teste.WPF
{
    /// <summary>
    /// Interaction logic for Sample_Converter.xaml
    /// </summary>
    public partial class Sample_Converter : Window
    {
        public Sample_Converter()
        {
            InitializeComponent();
        }
    }

    public class YesNoToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString().ToLower())
            {
                case "yes":
                case "sim":
                    return true;
                case "no":
                case "nao":
                case "não":
                    return false;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                    return "yes";                
            }

            return "no";
        }
    }
}
