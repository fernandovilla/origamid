using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Sample_Binding_2.xaml
    /// </summary>
    public partial class Sample_Binding_2 : Window
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public Sample_Binding_2()
        {
            InitializeComponent();

            users.Add(new User { Id = 1, Name = "Fernando Villa" });
            users.Add(new User { Id = 2, Name = "Denise Villa" });            

            listUsers.ItemsSource = users;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User { Id = 3, Name = "Maria Fernanda Villa" });
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (listUsers.SelectedItem != null)
            {
                string name = (listUsers.SelectedItem as User).Name;
                (listUsers.SelectedItem as User).Name = $"#{name}";
            }
        }

        private void btnDeleUser_Click(object sender, RoutedEventArgs e)
        {
            if (listUsers.SelectedItem != null)
            {
                var user = listUsers.SelectedItem as User;
                users.Remove(user);
            }
        }
    }

    public class User: INotifyPropertyChanged
    {
        private int id;
        private string name;

        public int Id { 
            get => id;
            set {
                if (id == value)
                    return;

                id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                    return;

                name = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrEmpty(propertyName))
                return;

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
