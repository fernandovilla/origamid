export default class ReceitaIngrediente {
  constructor(ingrediente) {
    this.id = ingrediente.id;
    this.nome = ingrediente.nome;
    this.percentual = ingrediente.percentual;
    this.precoCusto = ingrediente.precoCusto;
    this.ordem = ingrediente.ordem;
    this.ingrediente = ingrediente;
  }

  id = 0;
  nome = '';
  percentual = 0;
  precoCusto = 0;
  ingrediente = null;
  ordem = 0;
}
