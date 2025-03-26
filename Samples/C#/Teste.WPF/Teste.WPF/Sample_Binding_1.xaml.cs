using System;
using System.Collections.Generic;
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
    /// Interaction logic for Sample_Binding_1.xaml
    /// </summary>
    public partial class Sample_Binding_1 : Window
    {
        public Sample_Binding_1()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnUpdateSource_Click(object sender, RoutedEventArgs e)
        {
            var binding = txtWindowTitle.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }
    }
}
