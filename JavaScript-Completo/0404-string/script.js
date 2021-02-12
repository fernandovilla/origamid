const listaFruta = 'Morango, Banana, Maça';
console.log(listaFruta.includes("Banana"));
console.log(listaFruta.includes("Pera"));

const fruta = 'Banana';
console.log(fruta.startsWith('Ba'));
console.log(fruta.endsWith('NA'));
console.log(fruta.slice(-2));  //pega os 2 ultios caracteres
console.log(fruta.substring(0,4)); //pega os 4 primeiros caracteres. Substring não funciona com valor negativo

console.log(fruta.indexOf('a'));
console.log(fruta.lastIndexOf('a'));

console.log(`[${fruta.padStart(20,'.')}]`);
console.log(`[${fruta.padEnd(20,'.')}]`);

console.log(fruta.repeat(10));

let listaItens = 'Camisas Bonés Calças Bermuna Vestidos Saias';

//Relace simples troca apenas o primeiro caracter encontrado;
console.log(listaItens.replace(' ', ';')); 

//Replace com regular expression troca todos os caracteres encontrados;
console.log(listaItens.replace(/[ ]+/g, ';'));

const arrayItens = listaItens.split(' ');
console.log(arrayItens);

//Junta os itens do array numa string
console.log(arrayItens.join('|'));

//Exercícios...
//1. Usando foreach no array abaixo, some os valores de Taxa e os valores de Recebimento;

const transacoes = [
   { descricao: 'Taxa do Pão', valor: 'R$ 39', },
   { descricao: 'Taxa do Marcado', valor: 'R$ 129', },
   { descricao: 'Recebimento de Cliente', valor: 'R$ 99', },
   { descricao: 'Taxa do Banco', valor: 'R$ 129', },
   { descricao: 'Recebimento de Cliente', valor: 'R$ 49', },   
];

let somaTaxa = 0;
let somaRecebimento = 0;
transacoes.forEach((item) => {
   
   //Sinal + na frente da string converte para número...
   const valor = +item.valor.replace('R$', '').trim();

   if (item.descricao.substring(0,4).toUpperCase() == 'TAXA'){
      somaTaxa += valor;
   } else {
      somaRecebimento += valor;
   }   
});

console.log(`Soma Taxa: R$ ${somaTaxa}`);
console.log(`Soma Recebimento: R$ ${somaRecebimento}`);

//2. Substitua todos os <span> por <a>;
let html = `<ul>
               <li><span>Sobre</span></li>
               <li><span>Produtos</span></li>
               <li><span>Contato</span></li>
            </ul>`;

//Literalmente troca o conteúdo;
console.log(html.replace(/['span']+/g, 'a'));

//Quebra em um array e depois junta novamente com 'a';
console.log(html.split('span').join('a'));

//3. Retorne o último caracter da frase
const frase = 'Melhores do ano!';
console.log(frase.slice(-1));
