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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Teste.WPF.Customs
{
    /// <summary>
    /// Interaction logic for TextBoxButtonSearch.xaml
    /// </summary>
    public partial class TextBoxButtonSearch : UserControl
    {
        public TextBoxButtonSearch()
        {
            InitializeComponent();
        }

        public string Text
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public event RoutedEventHandler Click;

        private void onButtonClick(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(sender, e);
        }
    }
}
