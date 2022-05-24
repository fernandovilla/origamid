const contato = document.querySelector("#contato");
const button = contato.querySelector("input[type='submit']")  

const dados = {};

function handleChange(event) {
  dados[event.target.name] = event.target.value;
}

function handleClick(event){
  event.preventDefault();
  console.log(dados);
}

contato.addEventListener("change", handleChange);
button.addEventListener("click", handleClick);