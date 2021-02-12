/*
   const img = document.querySelector("img");

   function callback(e) {
   console.log(e);
   console.log("clicou!");
   }

   img.addEventListener("click", callback);
*/

function callbackLista(e) {
  console.log(e.currentTarget);
  console.log(e.target);
  console.log(e.type);
  console.log(e.path);
}

const animais = document.querySelector(".animais-lista");
animais.addEventListener("click", callbackLista);

/**** event.preventDefaut => Roda antes de um link ser direcionado para outra página ***********/

function handleLinkExterno(e) {
  e.preventDefault(); //previne que o link seja carregado...
  console.log("Clicou...");
}

const linkExterno = document.querySelector('a[href^="http"]');
linkExterno.addEventListener("click", handleLinkExterno);

//this dentro do callback do evento se refere sempre ao elemento 'ouvido'
/* Outros eventos... 
   click: quando é clicado sobre o elemento
   scroll: quando o scroll do elemento é 'rolado';
   resize: quando elemento é redimensionado;
   keydown: quando uma tecla é pressionada;
   keyup: quando uma tecla que estava pressioada é solta;
   mouseenter: quando o mouse entra na área do elemento
   'window' e 'document' também suportam eventos

   https://developer.mozilla.org/en-US/docs/Web/Events
*/

window.addEventListener("scroll", function () {
  console.log("scrolling the page...");
});

function handleKeydown(event) {
  if (event.key === "a") {
    document.body.classList.toggle("azul");
  }
}
window.addEventListener("keydown", handleKeydown);

/****** EXERCÍCIOS ************/
//1. Quando o usuário clicar nos links internos, adicione a classe 'ativo' no elemento clicado, removendo dos demais itens que a possuírem
//Previna o comportamento padrão desses links

function handleClickLinksInternos(e) {
  e.preventDefault();

  //Remove o 'ativo' de todos...
  linksInternos.forEach((link) => {
    link.classList.remove("ativo");
  });

  //Adiciona o 'ativo' ao item clicado...
  e.currentTarget.classList.add("ativo");
}

const linksInternos = document.querySelectorAll('a[href^="#"]');
linksInternos.forEach((item) =>
  item.addEventListener("click", handleClickLinksInternos),
);

//2. Selecione todos os elementos a parti do body, ao click do mouse mostre quais elementos estão sendo clicados...
function handleClickElemento(event) {
  console.log(`Clicado: ${event.target}`);
}

const elementos = document.querySelectorAll("body *");
elementos.forEach((item) => {
  item.addEventListener("click", handleClickElemento);
});

//3. Utlizando o código anterior, remova o elemento que está sendo clicado
function handleClickElemento(event) {
  event.currentTarget.remove();
}
const elementos2 = document.querySelectorAll("body *");
elementos2.forEach((item) => {
  item.addEventListener("click", handleClickElemento);
});

//4. Se usuário teclar 't', aumente o texto do site

function handleKeydownT(event) {
  if (event.key === "t") {
    document.documentElement.classList.toggle("textomaior");
  }
}

window.addEventListener("keydown", handleKeydownT);
