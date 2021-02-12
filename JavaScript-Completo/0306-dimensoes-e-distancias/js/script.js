const listaAnimais = document.querySelector(".animais-lista");
const height = listaAnimais.scrollHeight;
const offTop = listaAnimais.offsetTop;
const offLeft = listaAnimais.offsetLeft;

console.log(height);
console.log(offTop);
console.log(offLeft);

/*getBoudingClientRect() -> Método que retorna um objeto com valores de width, height, distâncias do elemento e mais */
const primeiroh2 = document.querySelector("h2");
const rect = primeiroh2.getBoundingClientRect();
console.log(rect);

/*window retorna dados da tela do usuário */
console.log(
  `iW: ${window.innerWidth}, ` +
    `oW: ${window.outerWidth}, ` +
    `iH: ${window.innerHeight}, ` +
    `oH: ${window.outerWidth}`,
);

/*matchMedia() -> utilizar como em media-querie no CSS para verificar largura do browser */
const small = window.matchMedia("(max-width: 600px)");
if (small.matches) {
  console.log("Tela menor que 600px");
} else {
  console.log("Tela maior que 600px");
}

/***** EXERCÍCIOS **********************************/
/*1. Verifique a distância da primeira imagem e relação do topo da página */
const img = document.querySelector("img");
console.log(`Top: ${img.offsetTop}`);

/*2. Retorne a soma da largura de todas as imagens */
function somaImagens() {
  const imagens = document.querySelectorAll("img");
  let soma = 0;
  imagens.forEach((item) => {
    soma += item.offsetWidth;
  });
  console.log(`Soma: ${soma}`);
}
window.onload = somaImagens;

/*3. Verifique se os links da página possúem o mínimo recomendado para telas utilizadas com o dedo (48px/48px) */
const links = document.querySelectorAll("a");
links.forEach((item) => {
  let boundingItem = item.getBoundingClientRect();
  if (boundingItem.width < 48 || boundingItem.height < 48) {
    console.log(`Item: ${item} não possui boa acessibilidade`);
  } else {
    console.log(`Item: ${item} OK`);
  }
});

/*4. Se o browser for menor que 720px adicione a classe menu-mobile ao menu */
const ehSmall = window.matchMedia("(max-width: 719px)").matches;
if (ehSmall) {
  const menu = document.querySelector(".menu");
  menu.classList.toggle("menu-mobile");
} else {
  const menu = document.querySelector(".menu");
  if (menu.classList.contains("menu-mobile"))
    menu.classList.remove("menu-mobile");
}
