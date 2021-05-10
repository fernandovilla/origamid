using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Teste.WPF.TreeView
{
    public class Person : TreeViewItemBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ObservableCollection<Person> Children { get; set; } = new ObservableCollection<Person>();
    }

    public class TreeViewItemBase : INotifyPropertyChanged
    {
        private bool isSelected;
        private bool isExpanded;

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (value != isSelected)
                {
                    this.isSelected = value;
                    NotifyPropertChanged();
                }
            }
        }

        public bool IsExpanded
        {
            get => this.isExpanded;
            set
            {
                if (value != this.isExpanded)
                {
                    this.isExpanded = value;
                    NotifyPropertChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
