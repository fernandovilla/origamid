function sampleArguments_Rest() {
  function perimetroForma(lado, totalLados = 4) {
    const arrayArgs = Array.from(arguments);

    arrayArgs.forEach((arg) => console.log(arg));

    return lado * totalLados;
  }

  //Deve existir apenas um parâmetro REST e também deve ser sempre o último
  function trataArgumentos(...listaArguments) {
    console.log(listaArguments);
  }

  //console.log(perimetroForma(10, 4));
  console.log(perimetroForma(15, 10, "oi", "cha cha cha"));
  trataArgumentos(1, "oi", 2.5, true, { id: 1, nome: "abc" }, [
    "banana",
    "maça",
    "goiaba",
  ]);
}

function sampleSpread() {
  const frutas = ["banana", "maçã", "morango"];
  const legumes = ["cebola", "cenoura", "berinjela"];

  const comida = [...frutas, "pizza", "lasanha", ...legumes].sort();
  console.log(comida);
}

function sampleSpread2() {
  function anunciaGanhadores(premio, ...ganhadores) {
    ganhadores.forEach((ganhador) =>
      console.log(`${ganhador} ganhou um ${premio}`),
    );
  }

  const ganhadores = ["pedro", "marta", "maria", "joão"];
  anunciaGanhadores("Carro", ...ganhadores);
}

function sampleSpread3() {
  const numeros = [25, 2, 3, 1, 4, 18, 44, 26, 32, 19];
  console.log(Math.max(...numeros));
}

function sampleSpread4() {
  const buttons = document.querySelectorAll("button");
  const arrayBtn = [...buttons];

  arrayBtn.forEach((b) => console.log(b.innerText));
}

function exercicio1() {
  function createButton(background = "blue", color = "red") {
    const buttonElement = document.createElement("button");
    buttonElement.style.background = background;
    buttonElement.style.color = color;
    buttonElement.style.display = "block";
    return buttonElement;
  }

  const redButton = createButton("red");
  const blueButton = createButton();

  document.body.appendChild(redButton);
  document.body.appendChild(blueButton);
}

function exercicio2() {
  const frutas = ["Banana", "Uva", "Laranja"];
  const comidas = ["Pizza", "Batata"];
  comidas.push("Lasanha", "Macarrão", ...frutas);
  comidas.sort();
  console.log(comidas);
}
