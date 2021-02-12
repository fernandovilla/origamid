function initSamples() {
  const carros = new Array("Ford", "Fiat", "Honda");

  //iteração 'array.forEach()';

  //array.forEach(callback_function(item, index, array)){...});

  console.log("Sample - Callback Function");
  carros.forEach(function (item, index, array) {
    console.log(item, index, array);
  });

  console.log("Sample - Arrow Function");
  carros.forEach((item, index, array) => {
    console.log(item, index, array);
  });

  const li = document.querySelectorAll("li");
  li.forEach((item, index) => {
    item.classList.add("ativa" + index);
  });

  li.forEach((i) => i.classList.add("ativo"));

  //iteração 'array.map()'
  const newCarros = carros.map((i) => i.toUpperCase());
  console.log(newCarros);

  //iteração 'array.reduce()' - acumulador;
  const numeros = [10, 111, 25, 30, 5, 80, 20, 110];

  const acumuladorNumeros = numeros.reduce((acumulador, item, index) => {
    console.log(acumulador, item);
    return acumulador + item;
  }, 0);
  console.log(acumuladorNumeros);

  const maior = numeros.reduce((acumulador, item) => {
    if (acumulador > item) return acumulador;

    return item;
  });
  console.log(maior);

  //iteração 'array.some()' - algum...
  const frutas = ["Banana", "Maça", "Uva"];
  const temUva = frutas.some((i) => i == "Uva");
  const temPera = frutas.some((i) => i == "Pêra");
  console.log(temUva);
  console.log(temPera);

  //iteração 'array.every()'
  const every = frutas.every((i) => i);
  console.log(every);

  //todos os numeros são maiores que 15?
  const everyMaior = numeros.every((i) => i >= 15);
  console.log(everyMaior);

  //iteração 'array.find()' e 'array.findIndex()'
  console.log(frutas);
  console.log("Existe 'Uva': " + frutas.find((i) => i === "Uva"));
  console.log("Index 'Uva'': " + frutas.findIndex((i) => i === "Uva"));

  //itareção 'array.filter()'
  const frutas2 = ["Banana", undefined, null, "Pêra", "Uva", 0, "Maça"];
  const frutasOk = frutas2.filter((i) => i);
  console.log(frutasOk);

  const numeros2 = [10, 20, 30, 40, 50, 60, 70];
  const maioresQue40 = numeros2.filter((i) => i > 40);
  console.log(maioresQue40);
}
//initSamples();

function initExercicios() {
  //EXERCÍCIOS:
  //1. Selecione cada curso e retorne um array com objetos contendo o título, descricao, aulas e horas de cada curso:
  const cursos = Array.from(document.querySelectorAll("section.curso"));
  console.log(cursos);

  const objectCursos = cursos.map((i) => {
    return {
      titulo: i.querySelector("h1").innerText,
      descricao: i.querySelector("p").innerText,
      aulas: i.querySelector(".aulas").innerText,
      horas: i.querySelector(".horas").innerText,
    };
  });
  console.log(objectCursos);

  //2. Retorne uma lista com os números maiores que 100;
  const numeros = [3, 44, 333, 23, 122, 322, 33];
  const maioresQue100 = numeros.filter((i) => i > 100);
  console.log(maioresQue100);

  //3. Verifique de 'Baixo' faz parte da lista de instrumentos e retorne 'true';
  const instrumentos = ["Guitarra", "Baixo", "Bateria", "Teclado"];
  const existeBaixo = instrumentos.some((i) => i === "Baixo");
  console.log(existeBaixo);

  //4. Retorne o valor total das compras
  const compras = [
    { item: "Banana", preco: "R$ 4,99" },
    { item: "Ovo", preco: "R$ 2,99" },
    { item: "Carne", preco: "R$ 25,49" },
    { item: "Refrigerante", preco: "R$ 5,35" },
    { item: "Queijo", preco: "R$ 10,60" },
  ];

  const total = compras.reduce((acum, item) => {
    const precoItem = +item.preco.replace("R$ ", "").replace(",", ".");
    return acum + precoItem;
  }, 0);
  console.log("Total: R$ " + total);
}
initExercicios();
