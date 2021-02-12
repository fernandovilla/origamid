/***************************************************************************************************
 * Exemplo #1: Uso de classe, diferença de 'function' e 'arrow function';
 **************************************************************************************************/
function exemplo1() {
  class Menu {
    constructor(menu) {
      this.menuElement = document.querySelector(menu);
      this.activeClass = 'active';
    }

    addActiveEvent() {
      // this.menuElement.addEventListener('click', function(event) { ... };
      this.menuElement.addEventListener('click', (event) => {
        // A função de callback cria um novo contexto pra ela, então this é ela própria e não mais a classe;
        // Arrow function como callback não cria um novo contexto, this é a classe;
        event.target.classList.toggle(this.activeClass);
      });
    }
  }

  console.log('OK');
  const menu = new Menu('.principal');
  menu.addActiveEvent();
}

/***************************************************************************************************
 * Exemplo #2: Desestruturação de array com spread
 **************************************************************************************************/
function exemplo2() {
  const itens = document.querySelectorAll('li');

  // Converter itens (nodelist) para array, usando Spread
  [...itens].map((item) => {
    console.log(item);
  });
}

/***************************************************************************************************
 * Exemplo #3: Clonar objeto com spread
 **************************************************************************************************/
function exemplo3() {
  const carro = { cor: 'Branco', portas: 4, ano: 2020 };
  const carro2 = carro;

  // Shadow Clone
  const carroClone = { ...carro, marca: 'Fiat' };

  console.log(carro, carroClone);
  console.log('carro === carroClone:', carro === carroClone);
  console.log('carro === carro2:', carro === carro2);
}

/***************************************************************************************************
 * Exemplo #4: Array filter, map e reduce
 **************************************************************************************************/
function exemplo4() {
  const precos = [
    'Crédito',
    'R$ 200',
    'R$ 400',
    'Contas Pagar',
    'R$ 300',
    'R$ 400',
    'Meus dados',
  ];

  const precosFilter = precos.filter((preco) => {
    return preco.includes('R$');
  });

  const precosNumerais = precosFilter.map((preco) => {
    return Number(preco.replace('R$ ', '').trim());
  });

  const total = precosNumerais.reduce((acumulador, item) => {
    console.log(acumulador, item);
    return acumulador + item;
  }, 0);
  console.log(total);
}
exemplo4();
