using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaBolo.UI.Views
{
    public partial class mdiPrincipal : Form
    {
        private int childFormNumber = 0;

        public mdiPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printSetupToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            using(var form = new Ingredientes.BuscaIngrediente())
            {
                form.ShowDialog();
            }
        }
    }
}
