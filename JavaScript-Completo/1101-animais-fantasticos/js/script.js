import ScrollSuave from "./modules/scroll-suave.js";
import Accordion from "./modules/accordion.js";
import TabNav from "./modules/tabnav.js";
import Modal from "./modules/modal.js";
import Tooltip from "./modules/tooltip.js";
import DropdownMenu from "./modules/dropdown-menu.js";
import MenuMobile from "./modules/menu-mobile.js";
import Funcionamento from "./modules/funcionamento.js";
import obterAnimais from "./modules/fetch-animais.js";
import fetchBitcoin from "./modules/fetch-bitcoin.js";
import ScrollAnima from "./modules/scroll-animacao.js";

//initScrollSuave();
const scrollSuave = new ScrollSuave('[data-menu="suave"] a[href^="#"]');
scrollSuave.init();

//initAccordion();
const accordion = new Accordion('[data-anime="accordion"] dt');
accordion.init();

//initTabNav();
const tabNav = new TabNav(
  '[data-tab="menu"] li',
  '[data-tab="content"] section',
);
tabNav.init();

//initModal();
const modal = new Modal(
  '[data-modal="abrir"]',
  '[data-modal="fechar"]',
  '[data-modal="container"]',
);
modal.init();

//initTooltip();
const tooltip = new Tooltip("[data-tooltip]");
tooltip.init();

//initFetchAnimais();
obterAnimais("./animaisapi.json", ".numeros-grid");

//initFetchBitcoin();
fetchBitcoin("https://blockchain.info/ticker", ".btc-preco");

//initDropdownMenu();
const dropdownMenu = new DropdownMenu('[data-dropdown]');
dropdownMenu.init();

//initMenuMobile();
const menuMobile = new MenuMobile('[data-menu="button"]', '[data-menu="list"]');
menuMobile.init();

//initAnimacaoScroll();
const scrollAnima = new ScrollAnima('[data-anime="scroll"]');
scrollAnima.init();

//initFuncionamento();
const funcionamento = new Funcionamento('[data-semana]');
funcionamento.init();