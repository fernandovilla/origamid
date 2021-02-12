const instrumentos = ["Guitarra", "Violão", "Baixo"];
const precos = [49, 99, 69, 89];

const dados = [
  new String("Tipo 1"), //string
  [
    "Carro",
    "Portas", //array
    {
      cor: "Azul",
      preco: 2000,
    },
  ],
  function andar(nome) {
    //função..
    console.log(nome);
  },
];

const carros = new Array("Corola", "Mustang", "Honda");
console.log(carros);
carros[20] = "Ferrari";
console.log(carros);
console.log(carros.length);

const li = document.querySelectorAll("li");
const arrayLi = Array.from(li); //Converte NodeList => Array
console.log(arrayLi);
console.log("li é array? " + Array.isArray(li));
console.log("arrayLi é array? " + Array.isArray(arrayLi));

//Conversão de 'objeto array'
const obj = {
  0: "Luis",
  1: "Fernando",
  2: "Villa",
  length: 3, //Obrigatório se quiser converter este objeto para Array
};

const objArray = Array.from(obj);
console.log(objArray);

//Criação de Array
const a1 = Array.of(10);
console.log(a1); //Size 1, valor: 10
const a2 = Array.of(1, 2, 3, 4, 5);
console.log(a2); //Size 5, valores: 1,2,3,4,5
const a3 = new Array(5);
console.log(a3); //Size 5, vazio
const a4 = Array(5);
console.log(a4); //Size 5, vazio
const a5 = Array(1, 2, 3, 4, 5);
console.log(a5); //Size 5, valores: 1,2,3,4,5

//Modificadores
console.log(instrumentos.sort()); //alinha strings
console.log(instrumentos); //array modificado...

// unshift: adiciona no início
console.log(carros);
carros.unshift("Mercedes", "Volvo");
console.log(carros);

// push: adiciona os itens no final
carros.push("Kia", "Jeep");
console.log(carros);

// shift: remove o primeiro item
carros.shift();
console.log(carros);

// pop: remove o ultimo item
carros.pop();
console.log(carros);

// reverse: inverte a ordem...
carros.reverse();
console.log(carros);

// splice: insere mais valores a partir do index e retorna os valores removidos
carros.splice(2, 0, "GM", "JAC");
console.log(carros);

// copyWithin
carros.copyWithin(2, 0, 2); //copia itens do proprio array
console.log(carros);

// fill
carros.fill("empty", 4, 21); //completa o array com o valor do primeiro argumento
console.log(carros);

// concat
const modelos = ["Fusca", "Gol", "Polo"];
const carrosModelos = carros.concat(modelos, "Punto", "Bravo"); //concatena os dois vetores, sem alterar os originais
console.log(carrosModelos);

const novosModelos = [].concat(carros, carrosModelos, "mais um");
console.log(novosModelos);

// includes: verifica se o array possui o valor
// indexOf: verifica se o array possui o valor e retorna o index
// lastIndexOf: retorna o index do ultimo item
console.log("includes('Volvo'): " + carros.includes("Volvo"));
console.log("indexOf('Ferrari'): " + carros.indexOf("Ferrari"));
console.log("lastIndexOf: " + carros.lastIndexOf("empty"));

// join: junta todos os itens do array em uma string, usando o caracter informado como separados. ',' é o separador default
console.log(carros.join(";"));
console.log(carros.join());

// slice: retorna os itens do array começando do início e indo até o final
// slice sem argumentos clona o array
console.log(carros.slice(10, 20));

//Exercpicios:
//1.  Remova o primeiro valor do array 'comidas';
//    Remova o ultimo item do array 'comidas';
//    Adicione 'Arroz' fo final do array;
//    Adicione 'Peixe' e 'Batata' no início do array
const comidas = ["Pizza", "Frango", "Carne", "Macarrão"];
console.log(comidas);
console.log("First Item: " + comidas.shift());
console.log("Last Item: " + comidas.pop());
console.log("Add 'Arroz': " + comidas.push("Arroz"));
console.log("Add 'Peixe, Batata': " + comidas.splice(0, 0, "Peixe", "Batata"));
console.log(comidas);

//2.  Arrume os estudantes em ordem alfabética
//    Inverta a ordem dos estudantes
//    Verifique se 'Joana' faz parte dos estudantes
//    Verifique se 'Juliana' faz parte dos estudantes
const estudantes = ["Marcio", "Brenda", "Joana", "Kleber", "Julia"];
console.log(estudantes.sort());
console.log(estudantes.reverse());
console.log("Joana: " + estudantes.includes("Joana"));
console.log("Juliana: " + estudantes.includes("Juliana"));

//3.  Substitua 'section' por 'ul' e 'div' por 'li' utilizando split e join;
let html = `<section>
               <div>Sobre</div>
               <div>Produtos</div>
               <div>Contato</div>
            </section>`;
html = html.split("section").join("ul").split("div").join("li");
console.log(html);
