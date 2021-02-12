function Pessoa(nome, idade) {
  this.nome = nome;
  this.idade = idade;
  this.andar = function () {
    return "Andou...";
  };
}

const fernando = new Pessoa("Fernando", 37);

Pessoa.prototype.andar2 = function () {
  return `${this.nome} andou...`;
};

console.log(fernando.prototype);
console.log(Pessoa.prototype);
