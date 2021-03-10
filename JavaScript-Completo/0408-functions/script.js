function initConteudoAula() {
  //function.lenght -> retorna o número do argumentos;
  //function.call() executa uma função;

  function darOi(nome) {
    console.log('Oi ' + nome);
  }

  darOi('Fernando');
  darOi.call({}, 'Dunha'); //{} = this

  //usando carro como this do método............................
  const carro = {
    marca: 'Ford',
    ano: 2018,
  };

  //quando this não é informado ele assume 'window';
  //Sample #1
  function descricaoCarro() {
    console.log(this.marca + ' ' + this.ano);
  }
  descricaoCarro();
  descricaoCarro.call();
  descricaoCarro.call(carro);

  //Sample #2
  const carros = ['Ford', 'Honda', 'Fiat'];
  const frutas = ['Banana', 'Maçã', 'Pêra', 'Jaca'];
  carros.forEach.call(frutas, (item, index) => {
    console.log(item, index); //item é uma fruta...
  });

  //Sample #3
  function Dom(seletor) {
    this.element = document.querySelector(seletor);
  }

  Dom.prototype.ativo = function (classe) {
    this.element.classList.add(classe);
  };

  const lista = new Dom('ul');
  lista.ativo('ativar');
  console.log(lista);

  //Sample #4
  const roupas = ['Camiseta', 'Bermuda', 'Vestido'];

  Array.prototype.showThis = function () {
    console.log(this);
  };

  roupas.showThis();

  Array.prototype.pop.call(frutas);
  roupas.pop();
  console.log(roupas);
  //............................................................

  //function.apply()
  const numeros = [1, 2, 3, 4, 5, 6, 7, 8, 500, 200, 20, 10];
  console.log(Math.max(numeros)); //não funciona...
  console.log(Math.max.call(null, numeros)); //não funciona...
  console.log(Math.max.apply(null, numeros)); //funciona...

  //function.bind()
  const $ = document.querySelectorAll.bind(document);
  console.log($('li.ativo'));

  //sample bind --------------------------------------
  carro.acelerar = function (aceleracao, tempo) {
    return `${this.marca} acelerou ${aceleracao} Km/h em ${tempo} segundos...`;
  };

  const ferrari = { marca: 'Ferrari' }; //semelhante ao objeto carro...

  const aceleracaoFerrari1 = carro.acelerar.bind(ferrari);
  console.log(aceleracaoFerrari1(100, 5));

  const aceleracaoFerrari2 = carro.acelerar.bind(ferrari, 200);
  console.log(aceleracaoFerrari2(13));

  const aceleracaoFerrari3 = carro.acelerar.bind(ferrari, 300, 20);
  console.log(aceleracaoFerrari3());
  //----------------------------------------------------
}
//initConteudoAula();

function initExercicios() {
  const $ = document.querySelectorAll.bind(document);

  //1. Retorne a soma total de caracteres dos parágrafos acima utilizando reduce...
  const p = $('section p');

  //método deve receber o mesmo número de argumentos do reduce();
  const somaChar = function (acumulador, element) {
    return acumulador + element.innerText.length;
  };

  const totalChars = Array.prototype.reduce.call(p, somaChar, 0);
  console.log('Total: ' + totalChars);

  //2. Crie uma função que retorne novos elementos html, com os seguintes argumentos: tag, classe e conteudo:
  function criarElemento(tag, classe, conteudo) {
    const newElement = document.createElement(tag);
    classe.length > 0 ? newElement.classList.add(classe) : null;
    conteudo.length > 0 ? (newElement.innerText = conteudo) : null;
    return newElement;
  }

  const novoP = criarElemento('p', 'azul', 'blablabla');
  console.log(novoP);

  //3. Crie uma nova função utilizando a anterior como base. Essa nova função deverá sempre criar h1 com a classe titulo. Porém o argumento 'conteudo' continuará dinâmico:

  const criarH1 = criarElemento.bind(null, 'h1', 'titulo');
  const novoH1 = criarH1('Meu título');
  console.log(novoH1);
}
initExercicios();
