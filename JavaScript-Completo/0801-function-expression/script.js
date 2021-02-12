// function somar(a, b) {
//   return a + b;
// }

// const dividir = function (a, b) {
//   return a / b;
// };

// const somar = (a, b) => a + b;
// const dobro = (a) => a * 2;

// //IIEF =
// (() => {
//   var instrumento = "Guitarra";
//   console.log(instrumento);
// })();

//Exercício 1
const active = (callback) => callback();

active(() => {
  console.log("Executei a função");
});
