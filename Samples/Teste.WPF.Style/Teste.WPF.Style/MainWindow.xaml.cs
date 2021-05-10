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
using TesteWPF.Style.Samples;

namespace Teste.WPF.Style
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTrigger_Click(object sender, RoutedEventArgs e)
        {
            var form = new Triggers();
            form.ShowDialog();
        }

        private void btnAnimations_Click(object sender, RoutedEventArgs e)
        {
            var form = new Animation_Triggers();
            form.ShowDialog();
        }

        private void btnTextBoxButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new TextBoxButton();
            form.ShowDialog();
        }
    }
}
