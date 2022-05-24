function initSetTimeout() {
  //Exemplo 1: setTimeout usando função
  function espera(texto) {
    console.log(texto);
  }
  setTimeout(espera, 5000, "Esperou 5 segundos...");

  //Exemplo 2: setTimeout em um for()
  for (let i = 0 i < 10 i++) {
    setTimeout(() => {
      console.log(i);
    }, 1000 * i);
  }
  console.log("Carregou o site...");

  //Exemplo 3: setTimeout em um evento
  const btn = document.querySelector("button");
  btn.addEventListener("click", handleClick);

  function handleClick() {
    setTimeout(() => {
      this.classList.toggle("ativo");
    }, 1000);
  }
}
//initSetTimeout();

function initSetInterval() {
  //Exemplo 1: setInterval em loop
  function loop(texto) {
    console.log(texto);
  }
  setInterval(loop, 10000, "Passou 10s...");

  //Exemplo 2: com arrow function
  let i = 0;
  const interval = setInterval(() => {
    console.log(`Passou ${++i * 10} segundos...`);
    if (i == 3) {
      clearInterval(interval);
    }
  }, 10000);
}
//initSetInterval();

function initExercicios() {
  //1. Mude a cor da tela para azul e depois vermelhor a cada 2 segundos...
  const body = document.querySelector("body");
  let i = 0;
  const interval = setInterval(() => {
    if (++i % 2 == 0) {
      body.style.background = "red";
    } else {
      body.style.background = "blue";
    }

    if (i > 10) {
      body.style.background = "none";
      clearInterval(interval);
    }
  }, 2000);
}
initExercicios();
