function initExemploObjeto1() {
  function Carro() {
    this.Marca = "";
    this.Preco = 0;
    this.toString = function () {
      return this.Marca;
    };
  }

  function CarroTaxado(marca, precoInicial) {
    this.Marca = marca;
    this.Preco = precoInicial;
    this.Taxa = 1.5;
    this.ValorTaxa = precoInicial * (this.Taxa / 100);
    this.PrecoFinal = this.Preco + this.ValorTaxa;
    this.toString = function () {
      return this.Marca;
    };
  }

  const honda = new Carro();
  honda.Marca = "Honda";
  console.log(honda);

  const carro2 = new CarroTaxado("Mitsubishi", 50000.0);
  console.log(carro2);
}
initExemploObjeto1();

function initExemploObject2() {
  const dom = {
    seletor: "li",
    element() {
      return document.querySelector(this.seletor);
    },
    ativar() {
      this.element().classList.add("ativar");
    },
  };

  function Dom(seletor) {
    this.element = function () {
      return document.querySelector(seletor);
    };
    this.ativar = function () {
      this.element().classList.add("ativar");
    };
  }

  const li = new Dom("li");
  const ul = new Dom("ul");
}
initExemploObject2();

function initExercicio1() {
  function Pessoa(nome, idade) {
    this.nome = nome;
    this.idade = idade;
    this.andar = function () {
      console.log(`${this.nome} está andando...`);
    };
  }

  const joao = new Pessoa("João", 20);
  const maria = new Pessoa("Maria", 25);
  const bruna = new Pessoa("Bruna", 15);

  joao.andar();
  maria.andar();
}
initExercicio1();

function initExercicio2() {
  function Dom(seletor) {
    const elementList = document.querySelectorAll(seletor);
    this.elements = elementList;

    this.addClass = function (classe) {
      this.elements.forEach((item) => {
        item.classList.add(classe);
      });
    };
    this.removeClass = function (classe) {
      this.elements.forEach((item) => {
        item.classList.removeClass(classe);
      });
    };
  }

  const dom = new Dom("li");
  dom.addClass("kkk");
}
initExercicio2();
