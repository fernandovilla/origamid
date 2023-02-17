export default class IngredienteReceita {
  constructor(id, nome, percent, custo) {
    this.id = id;
    this.nome = nome;
    this.percent = percent;
    this.custo = custo;
  }

  id = 0;
  nome = '';
  percent = 0;
  custo = 0;
}
