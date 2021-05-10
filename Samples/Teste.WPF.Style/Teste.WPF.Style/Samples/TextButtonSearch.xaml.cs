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

namespace TesteWPF.Style.Samples
{
    /// <summary>
    /// Interaction logic for TextButtonSearch.xaml
    /// </summary>
    public partial class TextButtonSearch : UserControl
    {
        public TextButtonSearch()
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
