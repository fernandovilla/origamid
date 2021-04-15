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

namespace Teste.WPF.Menus
{
    /// <summary>
    /// Interaction logic for SampleMenu.xaml
    /// </summary>
    public partial class SampleMenu : Window
    {
        private bool arquivoCriado = false;

        public SampleMenu()
        {
            InitializeComponent();
        }

        private void menuNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Criando arquivo...", Title, MessageBoxButton.OK, MessageBoxImage.Asterisk);
            arquivoCriado = arquivoCriado;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CommandOpen_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !arquivoCriado;
        }

        private void CommandOpen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Abrindo arquivo...", Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }



        private void btnContextMenu2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var menu2 = this.FindResource("menu2") as ContextMenu;
            menu2.PlacementTarget = (Button)sender;
            menu2.IsOpen = true;
        }

        private void CommandNew_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandSave_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void txtEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = txtEditor.GetLineIndexFromCharacterIndex(txtEditor.CaretIndex);
            int col = txtEditor.CaretIndex - txtEditor.GetCharacterIndexFromLineIndex(row);
            lblCursorPosition.Text = $"Line: {row + 1}, Char: {col + 1}";
        }

       
        private void slide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var color = Color.FromRgb((byte)slideR.Value, (byte)slideG.Value, (byte)slideB.Value);
            panelBorder.Background = new SolidColorBrush(color);
        }
    }
}
