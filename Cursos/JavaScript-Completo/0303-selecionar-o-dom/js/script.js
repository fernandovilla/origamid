/*
   const animais = document.getElementById("animais");
   console.log(animais);

   const gridSection = document.getElementsByClassName("grid-section");
   console.log(gridSection);

   const primeiraLI = document.querySelector("li");
   console.log(primeiraLI);

   const linkInterno = document.querySelector('[href^="#"]');
   console.log(linkInterno);

   const animaisIMG = document.querySelectorAll(".animais img");
   console.log(animaisIMG);

   const gridSectionHtml = document.getElementsByClassName("grid-section");
   const gridSectionNode = document.querySelectorAll(".grid-section");
   console.log(gridSectionHtml);
   console.log(gridSectionNode);

   const arrayHtml = Array.from(gridSectionHtml);
   arrayHtml.forEach(function (item, index) {
   console.log(index);
   });

   gridSectionNode.forEach(function (item, index, array) {
   console.log(index);
   });
*/

/*Retornar todas as imagens do site... */
const img = document.querySelectorAll("img");
img.forEach(function (item) {
  console.log(item.getAttribute("src"));
});

/*Retorne apenas as imagens que o src comece com 'imagem' */
const img2 = document.querySelectorAll('img[src^="img/imagem"]');
img2.forEach(function (item) {
  console.log(item.getAttribute("src"));
});

/*Selecione todos os links internos */
const linksInternos = document.querySelectorAll('a[href^="#"]');
console.log(linksInternos);

/*Selecione o primeiro h2 dentro de .animais-descricao */
const primeiroh2 = document.querySelector(".animais-descricao h2");
console.log(primeiroh2);

/*Selecione o ultimo <p> do site */
const p = document.querySelectorAll("p");
console.log(p[p.length - 1]);
