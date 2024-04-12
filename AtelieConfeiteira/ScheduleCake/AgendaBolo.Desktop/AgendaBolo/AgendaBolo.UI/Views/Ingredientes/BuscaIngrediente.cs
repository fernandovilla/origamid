using AgendaBolo.Domain.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaBolo.UI.Views.Ingredientes
{
    public partial class BuscaIngrediente : Form
    {
        public BuscaIngrediente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var unit = new UnitOfWork())
            {
                var repository = unit.IngredienteReopsitory;

                var ingredientes = repository.Search("1");

                if (ingredientes.Any())
                {
                    foreach (var i in ingredientes)
                    {
                        ///
                    }
                }
            }
        }
    }
}
