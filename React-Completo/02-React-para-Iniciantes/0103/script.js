/*****************************************************************************************
  >> EXEPLO 1: DESESTRUTURAÇÃO COM FUNÇÕES
*****************************************************************************************/
function exemplo1() {
  function handleMouse(event) {
    // Obtendo a posição do mouse usando desestruturação...
    const { clientX, clientY } = event;
    console.log('handleMouse()', clientX, clientY);
  }

  function handleMouse2({ clientX, clientY }) {
    // Obtendo a posição do mouse usando desestruturação nos argumentos da função
    console.log('handleMouse2()', clientX, clientY);
  }

  document.addEventListener('click', handleMouse2);

  /*****************************************************************************************
  >> EXEMPLO 2: DESESTRUTURAÇÃO COM ARRAY SIMPLES
*****************************************************************************************/
  const frutas = ['banana', 'maça', 'limão'];
  const [f0, f1, f2] = frutas;

  console.log(frutas);
  console.log(`f0: ${f0}`);
  console.log(`f1: ${f1}`);
  console.log(`f2: ${f2}`);
}

/*****************************************************************************************
  >> EXEMPLO 3: DESESTRUTURAÇÃO COM ARRAY COMPLEXAS
*****************************************************************************************/
function exemplo2() {
  const useQuadrado = [
    4,
    function (lado) {
      return 4 * lado;
    },
  ];

  const [lados, perimetro] = useQuadrado;
  console.log(`Lados: ${lados}`);
  console.log(`Perímetro: ${perimetro(5)}`);
}

/*****************************************************************************************
  >> EXEMPLO 3: REST E SPREAD
*****************************************************************************************/
function exemplo3() {
  function showList(empresa, clientes) {
    clientes.forEach((cliente) => {
      console.log(empresa, cliente);
    });
  }

  // Os '...' no segundo parâmetro é o Rest. Significa que, com excessão do primeiro parâmetro, os demais compoêm um array;
  function showListRest(empresa, ...clientes) {
    clientes.forEach((cliente) => {
      console.log(empresa, cliente);
    });
  }

  showList('Google', ['Fernando Villa', 'Microleme']);
  showListRest(
    'Microsoft',
    'Maria Fernanda Villa',
    'Denise Villa',
    'Minha empresa nova',
  );

  // Spread espalhas os itens de um array. Converte um array para ser usado como um argumento Rest
  const nomes = ['Fernando', 'Maria Fernanda', 'Denise'];
  showListRest('Villa', ...nomes); // Spread -> Rest

  // Concatenando array com spread
  const nomes2 = ['Aline', ...nomes, 'Suelen', 'Lucas'];
  showListRest('Villa', ...nomes2);

  // Objeto com desestruturação + spread para extensão do objeto
  const carro = {
    marca: 'Fiat',
    modelo: 'Bravo',
    cor: 'Branco Calahara',
    portas: 4,
  };

  const carroAno = { ...carro, ano: 2020 };
  console.log(carroAno);
}

/*****************************************************************************************
  >> EXEMPLO 4: MAP e FILTER
*****************************************************************************************/
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

  const precosFiltro = precos.filter((item) => {
    // Se bate com a condição do filtro, retornar 'true', senão 'false';
    return item.includes('R$');
  });
  console.log(precosFiltro);

  const precosNumericos = precosFiltro.map((preco) => {
    return preco.replace('R$', '').trim();
  });
  console.log(precosNumericos);
}
exemplo4();
