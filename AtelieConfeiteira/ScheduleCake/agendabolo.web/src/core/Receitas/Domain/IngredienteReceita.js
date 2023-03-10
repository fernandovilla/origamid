export default class IngredienteReceita {
  constructor(ingrediente) {
    this.id = ingrediente.id;
    this.nome = ingrediente.nome;
    this.percent = ingrediente.percent;
    this.precoCusto = ingrediente.precoCusto;
    this.ingrediente = ingrediente;
  }

  id = 0;
  nome = '';
  percentual = 0;
  precoCusto = 0;
  ingrediente = null;
}
