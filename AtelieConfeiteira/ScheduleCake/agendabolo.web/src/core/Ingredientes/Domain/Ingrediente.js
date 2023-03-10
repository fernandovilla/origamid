export default class Ingrediente {
  constructor(id, nome, precoCusto, quantidadeEmbalagem, status) {
    this.id = id;
    this.nome = nome;
    this.precoCusto = precoCusto;
    this.quantidadeEmbalagem = quantidadeEmbalagem;
    this.status = status;
  }

  id = 0;
  nome = '';
  precoCusto = 0;
  status = 0;
  quantidadeEmbalagem = 0;
}
