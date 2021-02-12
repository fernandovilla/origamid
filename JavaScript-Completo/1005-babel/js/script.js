import initScrollSuave from "./modules/scroll-suave.js";
import initScrollAnimacao from "./modules/scroll-animacao.js";
import initAccordion from "./modules/accordion.js";
import initTabNav from "./modules/tabnav.js";
import initModal from "./modules/modal.js";
import initTooltip from "./modules/tooltip.js";
import initDropdownMenu from "./modules/dropdown-menu.js";
import initMenuMobile from "./modules/menu-mobile.js";
import initAnimeNumeros from "./modules/anima-numeros.js";
import initFuncionamento from "./modules/funcionamento.js";

initScrollSuave();
initScrollAnimacao();
initAccordion();
initTabNav();
initModal();
initTooltip();
initDropdownMenu();
initMenuMobile();
initAnimeNumeros();
initFuncionamento();

/*
import $ from "jquery"; // como foi instalado com o npm, o node já sabe buscar na pasta 'node_modules'
import _ from "lodash"; // como foi instalado com o npm, o node já sabe buscar na pasta 'node_modules'

//$("nav").hide();         // jquery esconde o nav
const diferenca = _.difference(
  ["Banana", "Maçã", "Melão"],
  ["Banana", "Uva", "Pêra", "Mamão"],
);
console.log(diferenca);
*/
