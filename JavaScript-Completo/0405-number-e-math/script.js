console.log(Number.isNaN(NaN));  //true
console.log(Number.isNaN(1 + 5));  //false

console.log(Number.isInteger(1));   //true
console.log(Number.isInteger(1.5)); //false
console.log(parseInt(1.99));        //Retorna integer truncado

console.log(15.988.toFixed(2));     //transforma em string, arredonda
console.log(15.988.toString(2));    //transforma em string, arredonda

console.log(parseFloat("99.50"));
console.log(Number.parseFloat("$99.50"));
console.log(Number.parseFloat("100.99 reais"));

console.log(10.00.toLocaleString('en-US', {style: 'currency', currency: 'USD'}));
console.log(10.00.toLocaleString('pt-BR', {style: 'currency', currency: 'BRL'}));


console.log(Math.abs(-500));    //retorna valor absoluto
console.log(Math.ceil(5.353));        //arredonda sempre pra cima => 6
console.log(Math.floor(5.353));       //arredonda sempre pra baixo => 5    
console.log(Math.round(5.55));        //arredonda respeitando as regras da matemática

console.log(Math.max(5,10,15,35,2,1,0,100));
console.log(Math.min(5,10,15,35,2,1.5,100));

//Exercícios:
//1. Retorne um número aleatório entre 1050 e 2000;
const aleatorio = Math.random();
const numero = Math.floor(aleatorio*(2000-1050+1) + 1050);
console.log(numero);

//2. Retorne o maior número da lista abaixo
const numeros = '4, 5, 20, 8, 9';
console.log('Maior: ' + Math.max(numeros.split(', ')));
//Operador DISPREAD '...', separa o array em vários itens...
console.log('Maior: ' + Math.max(...numeros.split(', ')));


//3. Crie uma função para limpar os preços e retornar os números com centanvos arredondados depois retorne a soma total
console.log("EX2------------------------");

function limparPreco(preco){
   let precoLimpo = preco
         .toUpperCase()
         .replace(',','.')
         .replace('R$','')
         .trim();
   precoLimpo = Math.parseFloat(precoLimpo);
         
   return Math.parseFloat(precoLimpo);
};

const listaPrecos = ['R$ 59,99', ' R$ 100,222', 'R$ 230   ', 'r$ 200'];
let total = 0;
listaPrecos.forEach((item) => {
   const precoLimpo = limparPreco(item);   
   console.log(precoLimpo.toFixed(2));
   total += precoLimpo;
});
console.log("Total: " + total.toFixed(2));
