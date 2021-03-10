function initConteudoAula() {
  const h1 = document.querySelector('h1');
  console.log(Object.prototype.toString.call(h1));

  const div = document.querySelector('div');
  console.log(div.dataset.cor);
  console.log(div.dataset.width);

  const cor = document.querySelectorAll('[data-cor]');
  console.log(cor);

  const divAzul = document.querySelectorAll("[data-cor='azul']");
  console.log(divAzul);

  delete div.dataset.cor; //deleta o dataset
  div.dataset.cor = 'red'; //adiciona um novo dataset ou valor
}

function initExercicios() {
  //1. Adicione um atributo data-anime="show-down" e data-anime="show-right" a todas as sections com descricao dos animais;
  const sections = document.querySelectorAll('.animais-descricao section');
}
initExercicios();
