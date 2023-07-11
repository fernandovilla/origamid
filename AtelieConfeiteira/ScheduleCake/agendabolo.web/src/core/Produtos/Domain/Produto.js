import { TextToNumber } from '@/helpers/NumberHelp.js';

export default class Produto {
  constructor() {}

  id = 0;
  nome = '';
  descricao = '';
  observacoes = '';
  finalizacao = '';
  status = 1;
  pesoReferencia = 1000;
  receitas = [];

  static PrecoCustoReceitas(produto) {
    if (produto === null || produto === undefined) return 0;

    if (produto.receitas == null || produto.receitas === undefined) return 0;

    var total = produto.receitas.reduce((acumulado, receita) => {
      return (
        acumulado + this.CalcularCustoReceita(receita, produto.pesoReferencia)
      );
    }, 0);

    return total;
  }

  static CalcularPesoProporcionalReceita(receita, pesoReferencia) {
    if (receita === undefined || receita === null) return 0;
    return (pesoReferencia * (receita.percentual / 100)).toFixed(0);
  }

  static CalcularCustoReceita(receita, pesoReferencia) {
    if (receita === undefined || receita === null) return 0;

    if (receita.ingredientes === undefined || receita.ingredientes === null)
      return 0;

    var custoIngredientesQuilo = receita.ingredientes.reduce(
      (acumulado, item) => {
        return TextToNumber(item.precoCustoQuilo) + acumulado;
      },
      0,
    );

    var pesoReceitaNoProduto = this.CalcularPesoProporcionalReceita(
      receita,
      pesoReferencia,
    );
    var custoReceita = (custoIngredientesQuilo / 1000) * pesoReceitaNoProduto;

    return custoReceita;
  }
}
