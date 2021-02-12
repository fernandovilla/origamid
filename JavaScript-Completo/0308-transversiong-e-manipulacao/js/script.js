//Transversing é como navegar pelo DOM, utilizando suas propriedades e métodos;

let cont = 0;

function parent(item) {
  console.log(++cont);
  if (item.parentElement != null) {
    console.log(item.parentElement);
    parent(item.parentElement);
  } else {
    return null;
  }
}

const animaisLista = document.querySelector(".animais-lista");
parent(animaisLista);

//Retorna o próximo elemento...
console.log("Next...");
console.log(animaisLista.nextElementSibling);

//Retorna o elemento anterior...
console.log("Previous...");
console.log(animaisLista.previousElementSibling);

//Retorna os filhos do elemento...
console.log("Filhos...");
console.log(animaisLista.children);

//Selecionando o último elemento através de seletóres CSS...
console.log(animaisLista.querySelector("li:last-child"));

//Element X Node
//  Elementos são os códigos HTML, enquando Node é tudo que está dentro da tag selecionada (tags, quebra de linhas, comentários, etc...);

//Movendo elementos...
const contato = document.querySelector(".contato");
const titulo = contato.querySelector(".titulo");
const mapa = contato.querySelector("img");

const animais = document.querySelector(".animais");

//Adiciona a tag 'titulo' dentro da tag 'animais', no final...
//animais.appendChild(titulo);

//Move a tag 'animais' para dentro da tag 'contato', antes da tag 'titulo'...
//contato.insertBefore(animais, titulo);

//Remove a tag 'titulo' da tag 'contato'...
//contato.removeChild(titulo);

//Troca um elemento pelo outro...
//contato.replaceChild(mapa, titulo);

//Criação e inclusão de novos elementos...
const novoH1 = document.createElement("h1");
novoH1.innerText = "Novo Título";
novoH1.classList.add("titulo");
contato.appendChild(novoH1);

//Clone de elementos...
const h1 = document.querySelector("h1");
const faq = document.querySelector(".faq");
const cloneH1 = h1.cloneNode(true);
cloneH1.classList.add("azul");
faq.appendChild(cloneH1);

/****** EXERCÍCIOS **********/
const menu = document.querySelector(".menu");
const copy = document.querySelector(".copy");

const menuClonado = menu.cloneNode(true);
copy.appendChild(menuClonado);

//2. Selecione o primeiro 'dt' da 'dl' de .faq
const dl = faq.querySelector("dl");
const dt = dl.querySelector("dt");
console.log(dt);

//3. 'dd' referente ao primeio 'dt'
const dd = dt.nextElementSibling;
console.log(dd);
