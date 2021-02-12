/*
  var   => vaza o escopo do bloco;
  let   => não vaza o escopo do bloco;
  const => não vaza o escopo do bloco, é constante, impede de modificar o valor ou ser redeclarada

String:
 => Exemplo de 'String Template'

   var nome = "Fernando",
   sobreNome = "Villa";
   var nomeCompleto = `${nome} ${sobreNome}`;
   console.log(nomeCompleto);
*/

var idade = 37;
console.log(idade);

var exp = 2e10;
console.log(exp);

var modulo = 14 % 5;
console.log(`Mod: ${modulo}`);

//NaN => Not a Number
var numero = "1+3";
console.log(isNaN(numero)); //True => não é um número
console.log(numero);

var mult = (20 / 2) * 5;
console.log(mult);

var x = 1;
console.log(x++); //x = 1
console.log(x); //x = 2
console.log(++x); //x = 3;
console.log(x--); //x =3
console.log(x); //x = 2
console.log(--x); //x = 1

var idade = "37";
var somaIdade = 5;
console.log(+idade + somaIdade); //+idade é convertido para número

var peso = +"80" / 2;
var unidade = "kg";
var pesoUnidade = peso + unidade;
console.log(pesoUnidade);
