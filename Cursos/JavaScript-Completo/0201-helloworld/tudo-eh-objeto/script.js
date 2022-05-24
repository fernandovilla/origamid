/*** TESTE #1 ***********************************************/
var btnPlus = document.querySelector("#btnPlus");
var btnMinus = document.querySelector("#btnMinus");
var contador = 0;

btnPlus.addEventListener("click", function () {
  ++contador;
  mostraContador();
});

btnMinus.addEventListener("click", function () {
  --contador;
  mostraContador();
});

function mostraContador() {
  var pContador = document.querySelector("#contador");
  if (pContador != null) {
    pContador.textContent = contador;
  }
}

/*** TESTE #2 ***********************************************/
var btnLigar = document.querySelector("#btnLigar");

btnLigar.addEventListener("click", function () {
  var bloco = document.querySelector("#lampada");

  if (bloco != null) {
    if (bloco.classList.contains("ligado")) {
      console.log("Desligando...");
      bloco.classList.remove("ligado");
    } else {
      console.log("Ligando...");
      bloco.classList.add("ligado");
    }
  }
});
