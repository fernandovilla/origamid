function sample1() {
  const carro = {
    marca: "Honda",
    ano: 2018,
  };

  const { marca, ano } = carro;

  console.log(marca);
  console.log(ano);
}

function sample2() {
  const cliente = {
    nome: "Fernando",
    compras: {
      digitais: {
        livros: ["Livro I", "Livro II"],
        videos: ["Video I", "Video II"],
      },
      fisicas: {
        cadernos: ["Caderno I", "Caderno II", "Caderno III"],
      },
    },
  };

  // console.log(cliente.compras.digitais.livros);
  // console.log(cliente.compras.digitais.videos);

  // const { livros, videos } = cliente.compras.digitais;
  // console.log(livros);
  // console.log(videos);

  const {
    digitais,
    fisicas,
    digitais: { livros, videos },
  } = cliente.compras;

  console.log(fisicas);
  console.log(livros);

  //nomeCliente é um alias
  //email ão existe, mas assim é possível informa-la já com um valor default
  const { nome: nomeCliente, email = "email@gmail.com" } = cliente;
  console.log(nomeCliente);
  console.log(email);
}

function sample3() {
  const frutas = ["Banana", "Maça", "Pêra"];
  const [banana, maca, pera] = frutas;
  console.log(banana);
  console.log(maca);
  console.log(pera);
}

function sample4() {
  const [pera, maca, banana] = ["Pêra", "Maçã", "Banana"];
  console.log(pera);
  console.log(maca);
  console.log(banana);
}

function sample5() {
  function handleKeyup({ key, keyCode }) {
    console.log(key, keyCode);
  }
  document.addEventListener("keyup", handleKeyup);
}

function initExercicio1() {
  //Extrair style do elemento com destruction;
  const btn = document.querySelector("button");
  const btnStyle = getComputedStyle(btn);
  const { background, color, margin } = btnStyle;

  console.log(background);
  console.log(color);
  console.log(margin);
}

function initExercicio2() {
  //Trocar valor de variáveis com destruction
  let cursoAtivo = "JavaScript";
  let cursoInativo = "HTML";

  console.log(cursoAtivo, cursoInativo);
  [cursoAtivo, cursoInativo] = [cursoInativo, cursoAtivo];
  console.log(cursoAtivo, cursoInativo);
}
