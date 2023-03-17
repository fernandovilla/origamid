export default class ReceitaIngrediente {
  constructor(id, receita, ingrediente, percentual, ordem) {
    this.id = id;
    this.idReceita = receita.id;
    this.idIngrediente = ingrediente.id;
    this.percentual = percentual;
    this.ordem = ordem;
    this.nome = ingrediente.nome;
    this.precoCusto = ingrediente.precoCusto;
    this.ingrediente = ingrediente;
  }

  id = 0;
  idReceita = 0;
  idIngrediente = 0;
  percentual = 0;
  ordem = 0;
  nome = '';
  precoCusto = 0;
  ingrediente = null;
}
