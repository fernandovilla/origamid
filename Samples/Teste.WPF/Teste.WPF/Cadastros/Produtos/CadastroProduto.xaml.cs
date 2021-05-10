using System;
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
using System.Windows.Shapes;

namespace Teste.WPF.Cadastros.Produtos
{
    /// <summary>
    /// Interaction logic for CadastroProduto.xaml
    /// </summary>
    public partial class CadastroProduto : Window
    {
        IEnumerable<Embalagem> Embalagens;

        public CadastroProduto()
        {
            InitializeComponent();

            Embalagens = GetEmbalagens();
            lstEmbalagens.ItemsSource = Embalagens;
        }

        private IEnumerable<Embalagem> GetEmbalagens()
        {
            var embalagens = new List<Embalagem>();
            embalagens.Add(new Embalagem { Descricao = "UNITARIO", EAN = "7891111111111", Quantidade = 1 });
            embalagens.Add(new Embalagem { Descricao = "CAIXA COM 10", EAN = "7891234567890", Quantidade=10 });
            embalagens.Add(new Embalagem { Descricao = "FARDO COM 12", EAN = "7890000000001", Quantidade = 12 });

            return embalagens;
        }

        private void grupo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtGrupo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Selecione o grupo...", "Grupo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void txtGrupo_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void lstEmbalagens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtFabricante_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtLocalizacao_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
