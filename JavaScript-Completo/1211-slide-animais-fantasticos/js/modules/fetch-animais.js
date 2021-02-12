import AnimaNumeros from "./anima-numeros.js";

export default function obterAnimais(url, target) {
  //seleciona o elemento traget
  const numerosGrid = document.querySelector(target);

  //Cria o elemento contendo as informações de animal
  function createAnimalElement(animal) {
    const div = document.createElement("div");
    div.classList.add("numero-animal");
    div.innerHTML = `<h3>${animal.specie}</h3><span data-numero>${animal.total}</span>`;
    return div;
  }

  //cria um novo elemento, adiciona o conteúdo ao elemento e adiciona o elemento no target
  function fillAnimais(animal) {
    const divAnimal = createAnimalElement(animal);
    numerosGrid.appendChild(divAnimal);
  }

  //start a animação dos números de cada animação
  function animateAnimaisNumeros() {
    const animaNumeros = new AnimaNumeros("[data-numero]", ".numeros", "ativo");
    animaNumeros.init();
  }

  //obtem os dados de uma API remota ou local
  async function fetchAnimais() {
    try {
      // usando o fetch, conecta com a api e aguarda resposta
      const animaisResponse = await fetch(url);

      //transforma a resposta em json
      const animaisJSON = await animaisResponse.json();

      //após obter o conteúdo, preenche o dom
      animaisJSON.forEach((animal) => fillAnimais(animal));

      animateAnimaisNumeros();
    } catch (erro) {
      console.log(erro);
    }
  }

  return fetchAnimais();
}
