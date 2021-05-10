using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Teste.WPF.CustomTabControl;

namespace Teste.WPF.ListView
{
    /// <summary>
    /// Interaction logic for Sample_ListView.xaml
    /// </summary>
    public partial class Sample_ListView : Window
    {
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        public Sample_ListView()
        {
            InitializeComponent();

            CarregarDadosListViewDataBinding();
            CarregarDadosListViewSort();
            CarregarDadosListViewFilter();
        }

        private void CarregarDadosListViewDataBinding()
        {
            var users = new List<User>();
            users.Add(new User { Name = "Fernando Villa", Age = 38, Email = "fermvilla@gmail.com", Sex = "Masculino" });
            users.Add(new User { Name = "Maria Fernanda", Age = 3, Email = "mariafernandamoraesvilla@gmail.com", Sex = "Feminino" });
            users.Add(new User { Name = "Denise Villa", Age = 39, Email = "demoraesvilla@gmail.com", Sex = "Feminino" });

            lstDataBinding.ItemsSource = users;
            lstUsers.ItemsSource = users;

            lstUsers2.ItemsSource = users;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstUsers2.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Sex");
            view.GroupDescriptions.Add(groupDescription);


            var users3 = new List<User>();
            users3.Add(new User { Name = "Fernando Villa", Age = 38, Email = "fermvilla@gmail.com", Sex = "Masculino" });
            users3.Add(new User { Name = "Maria Fernanda", Age = 3, Email = "mariafernandamoraesvilla@gmail.com", Sex = "Feminino" });
            users3.Add(new User { Name = "Denise Villa", Age = 39, Email = "demoraesvilla@gmail.com", Sex = "Feminino" });

            lstUsers3.ItemsSource = users3;
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(lstUsers3.ItemsSource);
            PropertyGroupDescription groupDescription2 = new PropertyGroupDescription("Sex");
            view2.GroupDescriptions.Add(groupDescription2);
        }

        private void CarregarDadosListViewSort()
        {
            var users = new List<User>();
            users.Add(new User { Name = "Fernando Villa", Age = 38, Email = "fermvilla@gmail.com", Sex = "Masculino" });
            users.Add(new User { Name = "Maria Fernanda", Age = 3, Email = "mariafernandamoraesvilla@gmail.com", Sex = "Feminino" });
            users.Add(new User { Name = "Denise Villa", Age = 39, Email = "demoraesvilla@gmail.com", Sex = "Feminino" });
            users.Add(new User { Name = "José Carlos", Age = 10, Sex = "Masculino" });
            lstUsersSort.ItemsSource = users;
        }

        private void CarregarDadosListViewFilter()
        {
            var users = new List<User>();
            users.Add(new User { Name = "Fernando Villa", Age = 38 });
            users.Add(new User { Name = "José Dos Santos", Age = 40 });
            users.Add(new User { Name = "Antonio Alves", Age = 35 });
            users.Add(new User { Name = "Mario Sergio", Age = 59 });
            users.Add(new User { Name = "Osvaldo Pereira", Age = 52 });
            users.Add(new User { Name = "Lucas Ferreira", Age = 29 });
            users.Add(new User { Name = "Fernando Moraes", Age = 19 });
            lstUsersFilter.ItemsSource = users;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstUsersFilter.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
                return true;

            var user = item as User;

            return
                user.Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                user.Age.ToString().StartsWith(txtFilter.Text);

            //return (item as User).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sorty = column.Tag.ToString();

            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                lstUsersSort.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDirection = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDirection)
                newDirection = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDirection);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            lstUsersSort.Items.SortDescriptions.Add(new SortDescription(sorty, newDirection));
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lstUsersFilter.ItemsSource).Refresh();
        }
    }
}
