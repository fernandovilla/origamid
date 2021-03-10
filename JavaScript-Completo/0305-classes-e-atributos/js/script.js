/********* CLASSES *******************************************/

const menu = document.querySelector('.menu');
console.log(menu.classList);

/*Adiciona classes ao elemento */
menu.classList.add('azul', 'vermelho', 'preto');
menu.classList.add('roxo');

/*Remove classes do elemento */
menu.classList.remove('vermelho', 'preto');
menu.classList.remove('roxo');

/*Toggle: Adiciona se não existis, remove se existir */
menu.classList.toggle('pink'); /*Incluiu...*/
menu.classList.toggle('pink'); /*Removeu...*/

/*Verifica se existe um item na classe */
if (menu.classList.contains('azul')) menu.classList.add('azul-marinho');

/*Outra opção para atribuir valor na classe */
console.log(menu.className);
menu.className = 'menu';

/********* ATRIBUTOS ******************************************/
const animais = document.querySelector('.animais');
console.log(animais.attributes[0]);
console.log(animais.attributes['id']);

const img = document.querySelector('img');

/*Seleciona um atributo específico... */
console.log(img.getAttribute('src'));

/*Define o valor de um elemento... */
img.setAttribute('alt', 'É uma Raposa');
console.log(img.getAttribute('alt'));

/*Inclui um novo atribuito ao elemento... */
img.setAttribute('data-text', 'OK');
console.log(img.getAttribute('data-text'));
img.removeAttribute('data-text');

/*Verifica se existe o atributo... */
console.log(img.hasAttribute('alt'));
