
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
        return (item.precoCustoQuilo * item.percentual / 100) + acumulado;
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
      return acumulado + receita.percentual;
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

    return pesoReferencia * (receita.percentual / 100);
  }

  static CalcularPrecoCustoTotalProduto(produto, receitas) {
    var totalReceitas = this.CalcularPrecoCustoReceitas(receitas, produto.pesoReferencia);
    var valorMargemPreparo = totalReceitas * (produto.margemPreparo / 100);
    return totalReceitas + valorMargemPreparo + produto.custoMaoDeObra + produto.custoEmbalagem;
  }

  static CalcularPrecoVendaVarejo(produto, receitas) {
    var totalProdutos = this.CalcularPrecoCustoTotalProduto(produto, receitas);
    var valorMargem = totalProdutos * (produto.margemVendaVarejo / 100);
    return totalProdutos + valorMargem;
  }

  static CalcularPrecoVendaAtacado(produto, receitas) {
    var totalProdutos = this.CalcularPrecoCustoTotalProduto(produto, receitas);
    var valorMargem = totalProdutos * (produto.margemVendaAtacado / 100);
    return totalProdutos + valorMargem;
  }
}
