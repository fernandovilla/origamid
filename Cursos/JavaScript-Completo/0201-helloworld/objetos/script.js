var pessoa = {
  id: 1,
  nome: "Fernando",
  idade: 37,
};

console.log(pessoa);
pessoa.sobrenome = "Villa";
pessoa.nomeCompleto = function () {
  return `${this.nome} ${this.sobrenome}`;
};
console.log(pessoa.nomeCompleto());

var retangulo = {
  base: 4,
  altura: 2,
  area: function () {
    return this.base * this.altura;
  },
  Random() {
    return Math.random();
  },
};

console.log(retangulo.area());
console.log(retangulo.Random());
