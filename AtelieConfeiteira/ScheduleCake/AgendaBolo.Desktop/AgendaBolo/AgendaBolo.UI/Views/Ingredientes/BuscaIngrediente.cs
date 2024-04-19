using AgendaBolo.Domain.Database;
using AgendaBolo.Domain.Model.Ingredientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaBolo.UI.Views.Ingredientes
{
    public partial class BuscaIngrediente : FormDefault
    {
        private IEnumerable<IngredienteBusca> ingredientes;

        private IngredienteBusca CurrentIngrediente
        {
            get => (IngredienteBusca)ingredienteBuscaBindingSource.Current;
        }

        public BuscaIngrediente()
        {
            InitializeComponent();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string value = txtPesquisa.Text.Trim().ToUpper();

            using (var unit = new UnitOfWork())
            {
                var repository = unit.IngredienteReopsitory;
                ingredientes = repository.Search(value).ToList();
            }

            ingredienteBuscaBindingSource.DataSource = ingredientes;
            lblRodape.Text = $"Registrons encontrados: {ingredientes.Count()}";
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                btnPesquisa_Click(this, EventArgs.Empty);
        }

        private void BuscaIngrediente_Activated(object sender, EventArgs e)
        {
            txtPesquisa.Focus();
        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridIngredientes.Focus();
            }
        }

        private void gridIngredientes_Enter(object sender, EventArgs e)
        {

        }

        private void gridIngredientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;

                var c = CurrentIngrediente;
            }
        }
    }
}
