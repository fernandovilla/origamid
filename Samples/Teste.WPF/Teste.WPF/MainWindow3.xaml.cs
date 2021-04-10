using Microsoft.Win32;
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
    /// Interaction logic for WindowTbControl.xaml
    /// </summary>
    public partial class MainWindow3 : Window
    {
        private bool checkingAll = false;
        public MainWindow3()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void chkAllFeatures_Checked(object sender, RoutedEventArgs e)
        {
            checkingAll = true;

            bool newVal = (chkAllFeatures.IsChecked == true);
            chkFeatureABC.IsChecked = newVal;
            chkFeatureXYZ.IsChecked = newVal;
            chkFeatureWWW.IsChecked = newVal;

            checkingAll = false;
        }
       

        private void chkFeature_Checked(object sender, RoutedEventArgs e)
        {
            if (checkingAll)
                return;


            chkAllFeatures.IsChecked = false;
            if (chkFeatureABC.IsChecked == true && chkFeatureXYZ.IsChecked == true && chkFeatureWWW.IsChecked == true)
            {
                chkAllFeatures.IsChecked = true;
            }
            else if (chkFeatureABC.IsChecked == false && chkFeatureXYZ.IsChecked == false && chkFeatureWWW.IsChecked == false)
            {
                chkAllFeatures.IsChecked = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var form = new contato();
            form.ShowDialog();            
        }

        private void btnBinding1_Click(object sender, RoutedEventArgs e)
        {
            var form = new Sample_Binding_1();
            form.ShowDialog();
        }

        private void btnBinding2_Click(object sender, RoutedEventArgs e)
        {
            var form = new Sample_Binding_2();
            form.ShowDialog();
        }

        private void btnConverter_Click(object sender, RoutedEventArgs e)
        {
            var form = new Sample_Converter();
            form.ShowDialog();
        }

        private void btnStringFormat_Click(object sender, RoutedEventArgs e)
        {
            var form = new Sample_StringFormat();
            form.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Text file (*.txt)|*.txt";
            
            if (dialog.ShowDialog() == true)
            {
                MessageBox.Show($"Selected file: {dialog.FileName}", "File...", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnInputDialog_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialogs.InputDialog("Please, enter your name:", "");
            if (dialog.ShowDialog() == false)
                return;

            lblResposta.Content = dialog.Answer;
        }
    }
}
