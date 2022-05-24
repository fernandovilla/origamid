//Condicionais If e Else
var possuiGraduacao = false;
var possuiDoutorado = true;

if (possuiGraduacao) {
  console.log('Possui graduação!');
} else if (possuiDoutorado) {
  console.log('Possui doutorado!');
} else {
  console.log('Não possui nada!');
}

var nome = 'Fernando'; //Nome = Verdadeiro

if (nome) {
  console.log(nome);
} else {
  console.log('sem nome!');
}

//&& -> and, || -> Ou

var animal = 'Gato' && 'Cão';
if (animal) console.log(animal);
