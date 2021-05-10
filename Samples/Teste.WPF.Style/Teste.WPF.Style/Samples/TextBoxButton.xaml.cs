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

namespace TesteWPF.Style.Samples
{
    /// <summary>
    /// Interaction logic for TextBoxButton.xaml
    /// </summary>
    public partial class TextBoxButton : Window
    {
        public TextBoxButton()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler Click;

        private void onButtonClick(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(sender, e);
        }

        private void txtSearch_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(txtSearch.Text + $" - H:{txtSearch.Height}, W: {txtSearch.Width}");
        }

        private void txtSearch2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
