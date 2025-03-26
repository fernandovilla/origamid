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

namespace Teste.WPF
{
    /// <summary>
    /// Interaction logic for LimitedInput.xaml
    /// </summary>
    public partial class LimitedInput : UserControl
    {
        public LimitedInput()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string Title { get; set; }
        public int MaxLength { get; set; }
    }
}
