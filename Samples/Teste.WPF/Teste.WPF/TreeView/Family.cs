using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.WPF.TreeView
{
    public class Family
    {
        public string Name { get; set; }
        public ObservableCollection<FamilyMember> Members { get; set; } = new ObservableCollection<FamilyMember>();

    }
}
