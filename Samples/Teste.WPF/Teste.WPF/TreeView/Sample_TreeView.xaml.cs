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
using System.Windows.Shapes;

namespace Teste.WPF.TreeView
{
    /// <summary>
    /// Interaction logic for Sample_TreeView.xaml
    /// </summary>
    public partial class Sample_TreeView : Window
    {
        public Sample_TreeView()
        {
            InitializeComponent();

            LoadTreeView_ExempleSimple();

            LoadTreeView_ExempleFamily();

            LoadTreeView_ExemplePersons();

            LoadTreeView_ExempleLazyLoading();
        }

        private void LoadTreeView_ExempleSimple()
        {
            var root = new MenuItem { Title = "Menu" };

            var child1 = new MenuItem { Title = "Child #1" };
            child1.Items.Add(new MenuItem { Title = "Child #1.1" });
            child1.Items.Add(new MenuItem { Title = "Child #1.2" });

            var child2 = new MenuItem { Title = "Child #2" };

            root.Items.Add(child1);
            root.Items.Add(child2);

            trvMenu1.Items.Add(root);
        }

        private void LoadTreeView_ExempleFamily()
        {
            var families = new List<Family>();

            var family1 = new Family { Name = "Villa" };
            family1.Members.Add(new FamilyMember { Name = "Fernando Villa", Age = 37 });
            family1.Members.Add(new FamilyMember { Name = "Denise Villa", Age = 39 });
            family1.Members.Add(new FamilyMember { Name = "Maria Fernanda Villa", Age = 3 });

            var family2 = new Family { Name = "Dos Santos" };
            family2.Members.Add(new FamilyMember { Name = "José dos Santos", Age = 43 });
            family2.Members.Add(new FamilyMember { Name = "Sophia Alves dos Santos", Age = 40 });
            family2.Members.Add(new FamilyMember { Name = "Raul dos Santos", Age = 18 });
            family2.Members.Add(new FamilyMember { Name = "Luciana dos Santos", Age = 16 });

            families.Add(family1);
            families.Add(family2);

            trvFamily.ItemsSource = families;
        }

        private void LoadTreeView_ExemplePersons()
        {
            var persons = new List<Person>();
            var person1 = new Person { Name = "John Doe", Age = 42 };
            var person2 = new Person { Name = "Jone Doe", Age = 39, IsExpanded = true, IsSelected = true };
            var person3 = new Person { Name = "Becky Toe", Age = 25 };

            var child1 = new Person { Name = "Samy Doe", Age = 13 };
            var child2 = new Person { Name = "Jenny Moe", Age = 17 };

            person1.Children.Add(child1);
            person2.Children.Add(child1);
            person2.Children.Add(child2);

            persons.Add(person1);
            persons.Add(person2);
            persons.Add(person3);

            trvPersons.ItemsSource = persons;
        }

        private void LoadTreeView_ExempleLazyLoading()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
                trvStructure.Items.Add(CreateTreeItem(drive));
        }

        private TreeViewItem CreateTreeItem(object drive)
        {
            var item = new TreeViewItem();
            item.Header = drive.ToString();
            item.Tag = drive;
            item.Items.Add("Loading...");

            return item;
        }

        private void btnSelectNext_Click(object sender, RoutedEventArgs e)
        {
            if (trvPersons.SelectedItem != null)
            {
                var persons = (trvPersons.ItemsSource as List<Person>);
                int currentIndex = persons.IndexOf(trvPersons.SelectedItem as Person);

                if (currentIndex >= 0)
                    currentIndex++;

                if (currentIndex >= persons.Count)
                    currentIndex = 0;

                persons[currentIndex].IsSelected = true;
            }
        }

        private void btnToggleExpansion_Click(object sender, RoutedEventArgs e)
        {
            if (trvPersons.SelectedItem != null)
            {
                var person = trvPersons.SelectedItem as Person;
                person.IsExpanded = !person.IsExpanded;
            }
        }

        private void trvStructure_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (e.Source as TreeViewItem);

            if ((item.Items.Count == 1) && (item.Items[0] is string))
            {
                item.Items.Clear();
                DirectoryInfo expandedDir = null;

                if (item.Tag is DriveInfo)
                    expandedDir = (item.Tag as DriveInfo).RootDirectory;

                if (item.Tag is DirectoryInfo)
                    expandedDir = item.Tag as DirectoryInfo;

                try
                {
                    foreach (var subDir in expandedDir.GetDirectories())
                        item.Items.Add(CreateTreeItem(subDir));
                }
                catch { }
            }
        }
    }
}
