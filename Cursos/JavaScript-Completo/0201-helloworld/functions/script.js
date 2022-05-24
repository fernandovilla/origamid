function areaQuadrado(altura, lado) {
  var resultado = altura * lado;
  return resultado;
}

console.log(areaQuadrado(2, 2));

var contador = 0;
function log() {
  console.log(++contador);
}
/*
addEventListener("click", function () {
  console.log(++contador);
});
*/

function isTruthy(value) {
  console.log(!!value);
}

function perimetroQuadrado(lado) {
  return lado * 4;
}

function nomeCompleto(nome, sobrenome) {
  return `${nome} ${sobrenome}`;
}

function isEven(number) {
  if (number % 2 === 0) {
    console.log(`${number} é par!`);
  } else {
    console.log(`${number} não é par!`);
  }
}

function dataType(value) {
  console.log(typeof value);
}

addEventListener("click", isTruthy("fer"));
