﻿using System;
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
using Teste.WPF.ListView;
using Teste.WPF.TreeView;

namespace Teste.WPF
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("OK");
        }

        private void btnTesteCommands_Click(object sender, RoutedEventArgs e)
        {
            ShowForm(new Sample_Commands());
            
        }

        private void btnTelaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            ShowForm(new MainWindow3());
        }

        private void ShowForm(Window form)
        {
            form.Show();
        }

        private void btnTesteCommands2_Click(object sender, RoutedEventArgs e)
        {
            ShowForm(new Sample_Commands2());
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            var form = new Menus.SampleMenu();
            form.ShowDialog();
        }

        private void btnTabContro_Click(object sender, RoutedEventArgs e)
        {
            var form = new CustomTabControl.Sample_CustomTabControl();
            form.ShowDialog();
        }

        private void btnListView_Click(object sender, RoutedEventArgs e)
        {
            var form = new Sample_ListView();
            form.ShowDialog();
        }

        private void btnTreeView_Click(object sender, RoutedEventArgs e)
        {
            var form = new Sample_TreeView();
            form.ShowDialog();
        }

        private void btnProduto_Click(object sender, RoutedEventArgs e)
        {
            var form = new Cadastros.Produtos.CadastroProduto();
            form.ShowDialog();
        }

        private void btnComboBox_Click(object sender, RoutedEventArgs e)
        {
            var form = new ComboBoxes.Sample_ComboBox();
            form.ShowDialog();
        }
    }
}
