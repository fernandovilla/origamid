using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Teste.WPF.Menus;

namespace Teste.WPF.CustomTabControl
{
    /// <summary>
    /// Interaction logic for Sample_CustomTabControl.xaml
    /// </summary>
    public partial class Sample_CustomTabControl : Window
    {
        public Sample_CustomTabControl()
        {
            InitializeComponent();

            var items = new List<TodoItem>();
            items.Add(new TodoItem { Title = "Complete this WPF tutorial", Completion = 45 });
            items.Add(new TodoItem { Title = "Learn C#", Completion = 80 });
            items.Add(new TodoItem { Title = "Wash the car", Completion = 0 });
            icTodoList.ItemsSource = items;

            lstTodoList.ItemsSource = items;

            var buttons = new string[] { "OK", "Cancelar", "Avançar", "Retornar", "Sair", "Fechar" };
            icButtons.ItemsSource = buttons;

            cboColors.ItemsSource = typeof(Colors).GetProperties();

            CarregarDadosListViewDataBinding();
        }

        private void CarregarDadosListViewDataBinding()
        {
            var users = new List<User>();
            users.Add(new User { Name = "Fernando Villa", Age = "38", Email = "fermvilla@gmail.com", Sex = "Masculino" });
            users.Add(new User { Name = "Maria Fernanda", Age = "3", Email = "mariafernandamoraesvilla@gmail.com", Sex = "Feminino" });
            users.Add(new User { Name = "Denise Villa", Age = "39", Email = "demoraesvilla@gmail.com", Sex = "Feminino" });

            lstDataBinding.ItemsSource = users;
            lstUsers.ItemsSource = users;

            lstUsers2.ItemsSource = users;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstUsers2.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Sex");
            view.GroupDescriptions.Add(groupDescription);


            var users3 = new List<User>();
            users3.Add(new User { Name = "Fernando Villa", Age = "38", Email = "fermvilla@gmail.com", Sex = "Masculino" });
            users3.Add(new User { Name = "Maria Fernanda", Age = "3", Email = "mariafernandamoraesvilla@gmail.com", Sex = "Feminino" });
            users3.Add(new User { Name = "Denise Villa", Age = "39", Email = "demoraesvilla@gmail.com", Sex = "Feminino" });

            lstUsers3.ItemsSource = users3;
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(lstUsers3.ItemsSource);
            PropertyGroupDescription groupDescription2 = new PropertyGroupDescription("Sex");
            view2.GroupDescriptions.Add(groupDescription2);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (cboColors.SelectedIndex > 0)
                cboColors.SelectedIndex = cboColors.SelectedIndex - 1;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (cboColors.SelectedIndex < cboColors.Items.Count - 1)
                cboColors.SelectedIndex = cboColors.SelectedIndex + 1;
        }

        private void btnBlue_Click(object sender, RoutedEventArgs e)
        {
            cboColors.SelectedItem = typeof(Colors).GetProperty("Blue");
        }

        private void cboColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedColor = (Color)(cboColors.SelectedItem as PropertyInfo).GetValue(null, null);
            panelColor.Background = new SolidColorBrush(selectedColor);
        }
    }

    public class TodoItem
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }
}
