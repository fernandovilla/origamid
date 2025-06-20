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

  static CalcularPrecoCustoReceitasProduto(produto) {
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

  static CalcularPrecoCustoReceita(receita, pesoReferencia) {
    
    if (receita === undefined || receita === null) 
      return 0;

    if (!Array.isArray(receita.ingredientes) || receita.ingredientes === undefined || receita.ingredientes === null)
      return 0;

    var custoIngredientesQuilo = receita.ingredientes.reduce(
      (acumulado, item) => {
        return TextToNumber(item.precoCustoQuilo) + acumulado;
      }, 0,
    );

    var pesoReceitaNoProduto = this.CalcularPesoProporcionalReceita(receita, pesoReferencia);
    var custoReceita = (custoIngredientesQuilo / 1000) * pesoReceitaNoProduto;

    return custoReceita;
  }

  static CalcularPrecoCustoReceitas(receitas, pesoReferencia) {
    
    if (!Array.isArray(receitas) || receitas === undefined || receitas === null) 
      return 0;

    var total = receitas.reduce((acumulado, receita) => {
      return (
        acumulado +
        this.CalcularPrecoCustoReceita(receita, pesoReferencia)
      );
    }, 0);

    return total;
  }


  static CalcularPercentualTotalReceitas(receitas) {
    if (!Array.isArray(receitas) || receitas === undefined || receitas === null) 
      return 0;

    var total = receitas.reduce((acumulado, receita) => {
      return acumulado + TextToNumber(receita.percentual);
    }, 0);
    return total;
  }


  static CalcularPesoTotalReceitas(receitas, pesoReferencia) {
    if (!Array.isArray(receitas) || receitas === undefined || receitas === null) 
      return 0;

    var total = receitas.reduce((acumulado, receita) => {
      return (
        acumulado +
        this.CalcularPesoProporcionalReceita(receita, pesoReferencia)
      );
    }, 0);

    return total;
  }


  static CalcularPesoProporcionalReceita(receita, pesoReferencia) {
    if (receita === undefined || receita === null) 
      return 0;

    return pesoReferencia * (TextToNumber(receita.percentual) / 100);
  }

  static CalcularPrecoCustoTotalProduto(produto, receitas) {
    var totalReceitas = this.CalcularPrecoCustoReceitas(receitas, produto.pesoReferencia);

    var valorMargemPreparo =
      totalReceitas * (TextToNumber(produto.margemPreparo) / 100);

    return (
      totalReceitas +
      valorMargemPreparo +
      TextToNumber(produto.custoMaoDeObra) +
      TextToNumber(produto.custoEmbalagem)
    );
  }

  static CalcularPrecoVendaVarejo(produto, receitas) {
    var totalProdutos = this.CalcularPrecoCustoTotalProduto(produto, receitas);
    var valorMargem =
      (totalProdutos * TextToNumber(produto.margemVendaVarejo)) / 100;

    return (totalProdutos + valorMargem).toFixed(2);
  }

  static CalcularPrecoVendaAtacado(produto, receitas) {
    var totalProdutos = this.CalcularPrecoCustoTotalProduto(produto, receitas);

    console.log("totalProdutos:", totalProdutos);
    

    var valorMargem = (totalProdutos * TextToNumber(produto.margemVendaAtacado)) / 100;

    return (totalProdutos + valorMargem).toFixed(2);
  }
}
