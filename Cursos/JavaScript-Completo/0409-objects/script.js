function initConteudo() {
  // Object.getOwnPropertyDescriptors(obj) - Lista todos os métodos e propriedades, com suas devidas configurações...
  const carro = {
    marca: "Fiat",
    modelo: "Pálio",
    motor: "1.0",
  };

  //Lista todas as propriedades e métodos...
  console.log(Object.getOwnPropertyDescriptors(carro, "marca"));

  //Lista apenas uma propriedade...
  console.log(Object.getOwnPropertyDescriptor(carro, "marca"));

  ///////////////////////////////////////////////////////////////////////////
  // Object.keys(obj) - retornas um array com as propriedades enumeradas
  const moto = {
    marca: "Honda",
    modelo: "NXR Bros",
    capacete: true,
    motor: "160cc",
    rodas: {
      enumerable: true,
      configurable: false,
    },
  };

  console.log(Object.keys(moto));
  console.log(Object.values(moto));
  console.log(Object.entries(moto));

  Object.keys(moto).forEach((key) => {
    console.log(Object.getOwnPropertyDescriptor(moto, key));
  });

  ///////////////////////////////////////////////////////////////////////////
  // Object.getOwnPropertyNames(obj) - retornas um array com os nomes das propriedades do object
  console.log(Object.getOwnPropertyNames(moto));

  ///////////////////////////////////////////////////////////////////////////
  // Object.is(objA, objB) - compara se são os mesmo objectos
  const frutas = ["Banana", "Maça"];
  console.log(Object.is(carro, frutas));

  ///////////////////////////////////////////////////////////////////////////
  /*
  Object.freeze() - impede qualquer modificação no objeto;
      -> Object.isFrozen(obj)
  Object.seal() - impede a inclusão ou exclusão de propriedades;
      -> Object.isSealed(obj)
  Object.preventExtensions(obj) - impede a inclusão de novas propriedades;
      -> Object.isExtensible(obj)
*/

  //////////////////////////////////////////////////////////////////////////
  /*
  obj.hasOwnProperty(p) e obj.propertyIsEnumerable(p) - verifica se existe a propriedade e se a propriedade é enumeravel;
  obj.isPrototypeOf(valor) - verifica se é prototipo do valor informado;
*/
  console.log(Array.prototype.isPrototypeOf(frutas));
  console.log(Array.prototype.isPrototypeOf(carro));

  //////////////////////////////////////////////////////////////////////////
  // obj.toString() - retorna uma string do object
  console.log(carro.toString());
  console.log(frutas.toString());
  console.log(Object.prototype.toString.call(carro));
  console.log(Object.prototype.toString.call(frutas));
}
//initConteudo();

function initExercicios() {
  //1. Creie uma função e verifique corretamente o tipo de dado:
  const getTypeOf = function (obj) {
    return Object.prototype.toString.call(obj);
  };

  const a = { valor: "abc", posicao: 2 };
  const b = ["banana", "maçã", "pêra"];
  const c = 1.5;
  console.log(getTypeOf(a));
  console.log(getTypeOf(b));
  console.log(getTypeOf(c));

  //2. Crie um objeto 'quadrado' com as propriedades 'lados' e torne ela imutável
  const quadrado = {
    lados: 4,
  };
  Object.seal(quadrado);
  Object.freeze(quadrado);
  Object.preventExtensions(quadrado);

  quadrado.lados = 2;
  quadrado.area = () => {
    return lados * lados;
  };
  console.log(quadrado.lados);
  console.log(Object.getOwnPropertyDescriptors(quadrado));
}
initExercicios();
