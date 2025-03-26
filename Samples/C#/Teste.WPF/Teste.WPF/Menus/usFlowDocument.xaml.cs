using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Teste.WPF.Menus
{
    /// <summary>
    /// Interaction logic for usFlowDocument.xaml
    /// </summary>
    public partial class usFlowDocument : UserControl
    {
        public usFlowDocument()
        {
            InitializeComponent();
            cboFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(i => i.Source);
            cboFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cboFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboFontFamily.SelectedItem != null)
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cboFontFamily.SelectedItem);
        }

        private void cboFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cboFontSize.Text);
        }

        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var isBold = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (isBold != DependencyProperty.UnsetValue) && (isBold.Equals(FontWeights.Bold));

            var isItalic = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (isItalic != DependencyProperty.UnsetValue) && (isItalic.Equals(FontStyles.Italic));

            var isUnderline = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (isUnderline != DependencyProperty.UnsetValue) && (isUnderline.Equals(TextDecorations.Underline));

            var fontFamily = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cboFontFamily.SelectedItem = fontFamily;

            var fontSize = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cboFontSize.Text = fontSize.ToString();

        }

      

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Rich text format (*.rtf)|*.rtf|Text document (*.txt)|*.txt";
            if (dialog.ShowDialog() == true)
            {
                using(var stream = new FileStream(dialog.FileName, FileMode.Open))
                {
                    var range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                    range.Load(stream, DataFormats.Rtf);

                    stream.Flush();
                    stream.Close();
                }
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Rich text format (*.rtf)|*.rtf|Text document (*.txt)|*.txt";

            if (dialog.ShowDialog() == true)
            {
                using(var stream = new FileStream(dialog.FileName, FileMode.Create))
                {
                    var range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                    range.Save(stream, DataFormats.Rtf);
                }
            }
        }
    }
}
