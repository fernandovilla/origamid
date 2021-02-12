//console.log(window.history);
// window.history.pushState(null, null, "xxx.html");

// window.addEventListener("popstate", () => {
//   console.log("Teste");
// });

const links = document.querySelectorAll("a");
links.forEach((link) => {
  link.addEventListener("click", handleClick);
});

window.addEventListener("popstate", () => {
  fetchPage(window.location.href);
});

function handleClick(event) {
  event.preventDefault();
  fetchPage(event.target.href);
}

async function fetchPage(url) {
  if (url === window.location.href) return;

  document.querySelector(".content").innerText = "Carregando a página...";

  const response = await fetch(url); //faz o fetch na página...
  const pageText = await response.text(); //obtem o texto (html) da página...

  replaceContent(pageText);
  window.history.pushState(null, null, url); //troca a url...
}

function replaceContent(newText) {
  const newHtml = document.createElement("div");
  newHtml.innerHTML = newText;

  const oldContent = document.querySelector(".content");
  const newContent = newHtml.querySelector(".content");

  oldContent.innerHTML = newContent.innerHTML; //troca o conteúdo, renderizando o conteúdo de 'sobre' em 'index';
  document.title = newHtml.querySelector("title").innerText; //troca o título da página...
}
