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

  static CalcularPrecoCustoReceita(receita, pesoReferencia) {
    
    console.log(receita, pesoReferencia);

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

  static CalcularPrecoCustoReceitas(produto) {
    if (produto === null || produto === undefined) return 0;

    if (produto.receitas == null || produto.receitas === undefined) return 0;

    var total = produto.receitas.reduce((acumulado, receita) => {
      return (
        acumulado +
        this.CalcularPrecoCustoReceita(receita, produto.pesoReferencia)
      );
    }, 0);

    return total;
  }

  static CalcularPercentualTotalReceitas(produto) {
    if (produto.receitas === undefined) return 0;

    var total = produto.receitas.reduce((acumulado, receita) => {
      return acumulado + TextToNumber(receita.percentual);
    }, 0);
    return total;
  }

  static CalcularPesoTotalReceitas(produto) {
    if (produto.receitas == null) return 0;

    var total = produto.receitas.reduce((acumulado, receita) => {
      return (
        acumulado +
        this.CalcularPesoProporcionalReceita(receita, produto.pesoReferencia)
      );
    }, 0);

    return total;
  }

  static CalcularPesoProporcionalReceita(receita, pesoReferencia) {
    if (receita === undefined || receita === null) return 0;

    return pesoReferencia * (receita.percentual / 100);
  }

  static CalcularPrecoCustoTotalProduto(produto) {
    var totalReceitas = this.CalcularPrecoCustoReceitas(produto);
    var valorMargemPreparo =
      totalReceitas * (TextToNumber(produto.margemPreparo) / 100);

    return (
      totalReceitas +
      valorMargemPreparo +
      TextToNumber(produto.custoMaoDeObra) +
      TextToNumber(produto.custoEmbalagem)
    );
  }

  static CalcularPrecoVendaVarejo(produto) {
    var totalProdutos = this.CalcularPrecoCustoTotalProduto(produto);
    var valorMargem =
      (totalProdutos * TextToNumber(produto.margemVendaVarejo)) / 100;

    return (totalProdutos + valorMargem).toFixed(2);
  }

  static CalcularPrecoVendaAtacado(produto) {
    var totalProdutos = this.CalcularPrecoCustoTotalProduto(produto);
    var valorMargem =
      (totalProdutos * TextToNumber(produto.margemVendaAtacado)) / 100;

    return (totalProdutos + valorMargem).toFixed(2);
  }
}
