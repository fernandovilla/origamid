const contato = document.querySelector("#contato");
const texto = document.querySelector("#texto");
const check = contato.querySelector("input[type='checkbox']");

function handleChange(event) {
  const target = event.target;

  console.log(target.name);

  if (!target.checkValidity()) {
    target.setCustomValidity("Esse campo é muito importante");

    target.nextElementSibling.innerText = target.validationMessage;
  } else {
    if (target.classList.contains("invalid"))
      target.classList.remove("invalid");
  }

  /*
  console.log(event.target.value);
  console.log(event.target.checkValidity());
  */

  texto.innerText = event.target.value;
}

function handleChangeColor(event) {
  document.body.style.backgroundColor = event.target.value;
}

function handleCheckChange(event){
  if (event.target.checked){
    console.log("Checked true!");
  }
}

contato.addEventListener("change", handleChange);
contato.elements.cores.addEventListener("change", handleChangeColor);
check.addEventListener("change", handleCheckChange);

