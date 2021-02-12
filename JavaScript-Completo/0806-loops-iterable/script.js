function sample1() {
  //usando for...of
  const frutas = ["banana", "maçã", "morango", "laranja"];

  //retorna os itens do array
  for (let fruta of frutas) {
    console.log(fruta);
  }

  //retorna o index do array
  for (const i in frutas) {
    console.log(i + " - " + frutas[i]);
  }

  console.log(...frutas);
}

function sample2() {
  //usando o for...in
  const carro = {
    marca: "Honda",
    ano: 2018,
  };

  Object.defineProperties(carro, {
    portas: {
      value: 4,
      enumerable: false, //define que não será Symbol.iteration
    },
  });

  //retorna as propriedades do objeto
  for (let key in carro) {
    console.log(key + ": " + carro[key]);
  }
}

function sample3() {
  const button = document.querySelector("button");
  const btnStyles = getComputedStyle(button);

  for (const style in btnStyles) {
    console.log(`${style}: ${btnStyles[style]}`);
  }
}

function sample4() {
  //do...while
  let i = 0;
  do {
    console.log(i++);
  } while (i <= 10);
}

function exercicio1() {
  //Crie 4 li's na página. Utilizando for...of, adiciona uma classe a cada li:
  const lis = document.querySelectorAll("li");

  for (const li of lis) {
    li.classList.add("ativo");
  }
}

function exercicio2() {
  //Utilize o for...in para listar todas as propriedades e valores do objeto window:

  for (const p in window) {
    console.log(p + ": " + window[p]);
  }
}
exercicio2();
