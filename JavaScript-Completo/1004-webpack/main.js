/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./js/script.js");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./js/modules/accordion.js":
/*!*********************************!*\
  !*** ./js/modules/accordion.js ***!
  \*********************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return initAccordion; });\nfunction initAccordion() {\n  const accordionList = document.querySelectorAll(\n    '[data-anime=\"accordion\"] dt',\n  );\n  const activeClass = \"ativo\";\n\n  function activeAccordion() {\n    this.classList.toggle(activeClass);\n    this.nextElementSibling.classList.toggle(activeClass);\n  }\n\n  if (accordionList.length) {\n    accordionList[0].classList.add(activeClass);\n    accordionList[0].nextElementSibling.classList.add(activeClass);\n\n    accordionList.forEach((item) => {\n      item.addEventListener(\"click\", activeAccordion);\n    });\n  }\n}\n\n\n//# sourceURL=webpack:///./js/modules/accordion.js?");

/***/ }),

/***/ "./js/modules/anima-numeros.js":
/*!*************************************!*\
  !*** ./js/modules/anima-numeros.js ***!
  \*************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return initAnimaNumeros; });\nfunction initAnimaNumeros() {\n  function animaNumeros() {\n    const numeros = document.querySelectorAll(\"[data-numero]\");\n    numeros.forEach((item) => {\n      const total = +item.innerText;\n      const incremento = Math.floor(total / 100); //  arredonda para um número inteiro...\n\n      let start = 0;\n      const timer = setInterval(() => {\n        start += incremento;\n        item.innerText = start;\n\n        //  assim que o start for maior que o total, para a animação...\n        if (start > total) {\n          numeros.innerText = total;\n          clearInterval(timer);\n        }\n      }, 25 * Math.random());\n    });\n  }\n\n  function handleMutation(mutation) {\n    if (mutation[0].target.classList.contains(\"ativo\")) {\n      observer.disconnect(); // para a animação...\n      animaNumeros();\n    }\n  }\n\n  const observerTarget = document.querySelector(\".numeros\");\n  const observer = new MutationObserver(handleMutation);\n  observer.observe(observerTarget, { attributes: true });\n}\n\n\n//# sourceURL=webpack:///./js/modules/anima-numeros.js?");

/***/ }),

/***/ "./js/modules/dropdown-menu.js":
/*!*************************************!*\
  !*** ./js/modules/dropdown-menu.js ***!
  \*************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return initDropdownMenu; });\n/* harmony import */ var _outsideclick_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./outsideclick.js */ \"./js/modules/outsideclick.js\");\n\n\nfunction initDropdownMenu() {\n  const dropdownMenus = document.querySelectorAll(\"[data-dropdown]\");\n\n  dropdownMenus.forEach((menu) => {\n    //  touchstart é semelhante ao click, porém sem delay e funciona em mobile\n    [\"touchstart\", \"click\"].forEach((userEvent) => {\n      menu.addEventListener(userEvent, handleClick);\n    });\n  });\n\n  function handleClick(event) {\n    event.preventDefault();\n\n    this.classList.add(\"active\");\n    //  prepara o menu para sumir quando usuário clicar fora\n    Object(_outsideclick_js__WEBPACK_IMPORTED_MODULE_0__[\"default\"])(this, [\"touchstart\", \"click\"], () => {\n      this.classList.remove(\"active\");\n    });\n  }\n}\n\n\n//# sourceURL=webpack:///./js/modules/dropdown-menu.js?");

/***/ }),

/***/ "./js/modules/funcionamento.js":
/*!*************************************!*\
  !*** ./js/modules/funcionamento.js ***!
  \*************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return initFuncionento; });\nfunction initFuncionento() {\r\n  const funcionamento = document.querySelector(\"[data-semana]\");\r\n  const diasSemana = funcionamento.dataset.semana.split(\",\").map(Number);\r\n  const horarioSemana = funcionamento.dataset.horario.split(\",\").map(Number);\r\n\r\n  const dataAgora = new Date();\r\n  const diaAgora = dataAgora.getDay();\r\n  const horarioAgora = dataAgora.getHours();\r\n\r\n  const semanaAberto = diasSemana.indexOf(diaAgora) > -1;\r\n  const horarioAberto =\r\n    horarioAgora >= horarioSemana[0] && horarioAgora < horarioSemana[1];\r\n\r\n  if (semanaAberto && horarioAberto) {\r\n    funcionamento.classList.add(\"aberto\");\r\n  } else {\r\n    funcionamento.classList.remove(\"aberto\");\r\n  }\r\n}\r\n\r\n/*\r\n   //Exemplo...\r\n   const agora = new Date();\r\n   const natal = new Date(\"Dec 24 2020 23:59:00\");\r\n\r\n   function converterEmDias(time) {\r\n   return time / (24 * 60 * 60 * 1000); //horas_dia * minutos_hora * segundos_minuto * milessigundos_segundo\r\n   }\r\n\r\n   const diasAgora = converterEmDias(agora);\r\n   const diasNatal = converterEmDias(natal);\r\n\r\n   const faltamDiasParaNatal = diasNatal - diasAgora;\r\n   console.log(faltamDiasParaNatal);\r\n*/\r\n\n\n//# sourceURL=webpack:///./js/modules/funcionamento.js?");

/***/ }),

/***/ "./js/modules/menu-mobile.js":
/*!***********************************!*\
  !*** ./js/modules/menu-mobile.js ***!
  \***********************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return initMenuMobile; });\n/* harmony import */ var _outsideclick_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./outsideclick.js */ \"./js/modules/outsideclick.js\");\n\r\n\r\nfunction initMenuMobile() {\r\n  const menuButton = document.querySelector(\"[data-menu='button']\");\r\n  const menuList = document.querySelector(\"[data-menu='list']\");\r\n  const eventos = [\"click\", \"touchstart\"];\r\n\r\n  if (menuButton) {\r\n    function openMenu(event) {\r\n      menuButton.classList.add(\"active\");\r\n      menuList.classList.add(\"active\");\r\n\r\n      Object(_outsideclick_js__WEBPACK_IMPORTED_MODULE_0__[\"default\"])(menuList, eventos, () => {\r\n        menuList.classList.remove(\"active\");\r\n        menuButton.classList.remove(\"active\");\r\n      });\r\n    }\r\n\r\n    eventos.forEach((evento) => menuButton.addEventListener(evento, openMenu));\r\n  }\r\n}\r\n\n\n//# sourceURL=webpack:///./js/modules/menu-mobile.js?");

/***/ }),

/***/ "./js/modules/modal.js":
/*!*****************************!*\
  !*** ./js/modules/modal.js ***!
  \*****************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return initModal; });\nfunction initModal() {\r\n  const botaoAbrir = document.querySelector('[data-modal=\"abrir\"]');\r\n  const botaoFechar = document.querySelector('[data-modal=\"fechar\"]');\r\n  const containerModal = document.querySelector('[data-modal=\"container\"]');\r\n\r\n  if (botaoAbrir && botaoFechar && containerModal) {\r\n    function toggleModal(event) {\r\n      event.preventDefault();\r\n      containerModal.classList.toggle(\"ativo\");\r\n    }\r\n\r\n    function cliqueForaModal(event) {\r\n      if (this === event.target) {\r\n        toggleModal(event);\r\n      }\r\n    }\r\n\r\n    botaoAbrir.addEventListener(\"click\", toggleModal);\r\n    botaoFechar.addEventListener(\"click\", toggleModal);\r\n    containerModal.addEventListener(\"click\", cliqueForaModal);\r\n  }\r\n}\r\n\n\n//# sourceURL=webpack:///./js/modules/modal.js?");

/***/ }),

/***/ "./js/modules/outsideclick.js":
/*!************************************!*\
  !*** ./js/modules/outsideclick.js ***!
  \************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return outsideClick; });\n//método que vai ocorrer na fase de 'bubble'\r\nfunction outsideClick(element, events, callbackFunction) {\r\n  const html = document.documentElement;\r\n  const outsideAttribute = \"data-outside\";\r\n\r\n  //coloca um attributo no elemento para que o evento 'click' seja incluído apenas uma vez no html\r\n  if (!element.hasAttribute(outsideAttribute)) {\r\n    events.forEach((userEvent) => {\r\n      setTimeout(() => html.addEventListener(userEvent, handleOutsideClick));\r\n    });\r\n\r\n    element.setAttribute(outsideAttribute, \"\");\r\n  }\r\n\r\n  function handleOutsideClick(event) {\r\n    //se o elemento clicado não for o próprio menu ou tens dele...\r\n    if (!element.contains(event.target)) {\r\n      element.removeAttribute(outsideAttribute);\r\n      events.forEach((userEvent) => {\r\n        html.removeEventListener(userEvent, handleOutsideClick);\r\n      });\r\n      callbackFunction();\r\n    }\r\n  }\r\n}\r\n\n\n//# sourceURL=webpack:///./js/modules/outsideclick.js?");

/***/ }),

/***/ "./js/modules/scroll-animacao.js":
/*!***************************************!*\
  !*** ./js/modules/scroll-animacao.js ***!
  \***************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return initScrollAnimacao; });\nfunction initScrollAnimacao() {\r\n  const sections = document.querySelectorAll('[data-anime=\"scroll\"]');\r\n  const windowMetade = window.innerHeight * 0.6;\r\n\r\n  function animaScroll() {\r\n    sections.forEach((section) => {\r\n      const sectionTop = section.getBoundingClientRect().top;\r\n      const isSectionVisible = sectionTop - windowMetade < 0;\r\n\r\n      if (isSectionVisible) {\r\n        section.classList.add(\"ativo\");\r\n      } else if (section.classList.contains(\"ativo\")) {\r\n        section.classList.remove(\"ativo\");\r\n      }\r\n    });\r\n  }\r\n\r\n  if (sections.length) {\r\n    animaScroll();\r\n    window.addEventListener(\"scroll\", animaScroll);\r\n  }\r\n}\r\n\n\n//# sourceURL=webpack:///./js/modules/scroll-animacao.js?");

/***/ }),

/***/ "./js/modules/scroll-suave.js":
/*!************************************!*\
  !*** ./js/modules/scroll-suave.js ***!
  \************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return initScrollSuave; });\n\r\nfunction initScrollSuave() {\r\n   const linksInternos = document.querySelectorAll('[data-menu=\"suave\"] a[href^=\"#\"]');\r\n \r\n   function scrollToSection(event) {\r\n     event.preventDefault();\r\n     const href = event.currentTarget.getAttribute('href');\r\n     const section = document.querySelector(href);\r\n     section.scrollIntoView({\r\n       behavior: 'smooth',\r\n       block: 'start',\r\n     });\r\n \r\n     // forma alternativa\r\n     // const topo = section.offsetTop;\r\n     // window.scrollTo({\r\n     //   top: topo,\r\n     //   behavior: 'smooth',\r\n     // });\r\n   }\r\n \r\n   linksInternos.forEach((link) => {\r\n     link.addEventListener('click', scrollToSection);\r\n   });\r\n }\n\n//# sourceURL=webpack:///./js/modules/scroll-suave.js?");

/***/ }),

/***/ "./js/modules/tabnav.js":
/*!******************************!*\
  !*** ./js/modules/tabnav.js ***!
  \******************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return initTabNav; });\nfunction initTabNav() {\r\n   const tabMenu = document.querySelectorAll('[data-tab=\"menu\"] li');\r\n   const tabContent = document.querySelectorAll('[data-tab=\"content\"] section');\r\n \r\n   if(tabMenu.length && tabContent.length) {\r\n     tabContent[0].classList.add('ativo');\r\n \r\n     function activeTab(index) {\r\n       tabContent.forEach((section) => {\r\n         section.classList.remove('ativo');\r\n       });\r\n       const direcao = tabContent[index].dataset.anime;\r\n       tabContent[index].classList.add('ativo', direcao);\r\n     }\r\n \r\n     tabMenu.forEach((itemMenu, index) => {\r\n       itemMenu.addEventListener('click', () => {\r\n         activeTab(index);\r\n       });\r\n     });\r\n   }\r\n }\n\n//# sourceURL=webpack:///./js/modules/tabnav.js?");

/***/ }),

/***/ "./js/modules/tooltip.js":
/*!*******************************!*\
  !*** ./js/modules/tooltip.js ***!
  \*******************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return initTooltip; });\nfunction initTooltip() {\r\n  const tooltips = document.querySelectorAll(\"[data-tooltip]\");\r\n\r\n  if (tooltips) {\r\n    const onMouseLeave = {\r\n      tooltipbox: \"\",\r\n      element: \"\",\r\n      handleEvent() {\r\n        this.tooltipbox.remove();\r\n        this.element.removeEventListener(\"mouseleave\", onMouseLeave);\r\n        this.element.removeEventListener(\"mousemove\", onMouseMove);\r\n      },\r\n    };\r\n\r\n    const onMouseMove = {\r\n      tooltipbox: \"\",\r\n      handleEvent(event) {\r\n        this.tooltipbox.style.top = event.pageY + 15 + \"px\";\r\n        this.tooltipbox.style.left = event.pageX + 12 + \"px\";\r\n      },\r\n    };\r\n\r\n    function criarTooltipBox(element) {\r\n      const tooltipBox = document.createElement(\"div\");\r\n      const text = element.getAttribute(\"aria-label\");\r\n      tooltipBox.classList.add(\"tooltip\");\r\n      tooltipBox.innerText = text;\r\n\r\n      return tooltipBox;\r\n    }\r\n\r\n    function onMouseOver(event) {\r\n      const tooltipbox = criarTooltipBox(this); //  this é o elemento que ocorreu o evento\r\n\r\n      document.body.appendChild(tooltipbox);\r\n      tooltipbox.style.top = `${event.pageY + 12}px`; //  adiciona mais 15px para o cursor do mouse não ficar sobre o div da tooltip\r\n      tooltipbox.style.left = `${event.pageX + 12}px`;\r\n\r\n      onMouseMove.tooltipbox = tooltipbox;\r\n      this.addEventListener(\"mousemove\", onMouseMove);\r\n\r\n      onMouseLeave.element = this;\r\n      onMouseLeave.tooltipbox = tooltipbox;\r\n      this.addEventListener(\"mouseleave\", onMouseLeave);\r\n    }\r\n\r\n    //function onMouseLeave(event) {}\r\n\r\n    tooltips.forEach((item) => {\r\n      item.addEventListener(\"mouseover\", onMouseOver);\r\n    });\r\n  }\r\n}\r\n\n\n//# sourceURL=webpack:///./js/modules/tooltip.js?");

/***/ }),

/***/ "./js/script.js":
/*!**********************!*\
  !*** ./js/script.js ***!
  \**********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var _modules_scroll_suave_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./modules/scroll-suave.js */ \"./js/modules/scroll-suave.js\");\n/* harmony import */ var _modules_scroll_animacao_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./modules/scroll-animacao.js */ \"./js/modules/scroll-animacao.js\");\n/* harmony import */ var _modules_accordion_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./modules/accordion.js */ \"./js/modules/accordion.js\");\n/* harmony import */ var _modules_tabnav_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./modules/tabnav.js */ \"./js/modules/tabnav.js\");\n/* harmony import */ var _modules_modal_js__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./modules/modal.js */ \"./js/modules/modal.js\");\n/* harmony import */ var _modules_tooltip_js__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./modules/tooltip.js */ \"./js/modules/tooltip.js\");\n/* harmony import */ var _modules_dropdown_menu_js__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./modules/dropdown-menu.js */ \"./js/modules/dropdown-menu.js\");\n/* harmony import */ var _modules_menu_mobile_js__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./modules/menu-mobile.js */ \"./js/modules/menu-mobile.js\");\n/* harmony import */ var _modules_anima_numeros_js__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./modules/anima-numeros.js */ \"./js/modules/anima-numeros.js\");\n/* harmony import */ var _modules_funcionamento_js__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./modules/funcionamento.js */ \"./js/modules/funcionamento.js\");\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nObject(_modules_scroll_suave_js__WEBPACK_IMPORTED_MODULE_0__[\"default\"])();\r\nObject(_modules_scroll_animacao_js__WEBPACK_IMPORTED_MODULE_1__[\"default\"])();\r\nObject(_modules_accordion_js__WEBPACK_IMPORTED_MODULE_2__[\"default\"])();\r\nObject(_modules_tabnav_js__WEBPACK_IMPORTED_MODULE_3__[\"default\"])();\r\nObject(_modules_modal_js__WEBPACK_IMPORTED_MODULE_4__[\"default\"])();\r\nObject(_modules_tooltip_js__WEBPACK_IMPORTED_MODULE_5__[\"default\"])();\r\nObject(_modules_dropdown_menu_js__WEBPACK_IMPORTED_MODULE_6__[\"default\"])();\r\nObject(_modules_menu_mobile_js__WEBPACK_IMPORTED_MODULE_7__[\"default\"])();\r\nObject(_modules_anima_numeros_js__WEBPACK_IMPORTED_MODULE_8__[\"default\"])();\r\nObject(_modules_funcionamento_js__WEBPACK_IMPORTED_MODULE_9__[\"default\"])();\r\n\r\n/*\r\nimport $ from \"jquery\"; // como foi instalado com o npm, o node já sabe buscar na pasta 'node_modules'\r\nimport _ from \"lodash\"; // como foi instalado com o npm, o node já sabe buscar na pasta 'node_modules'\r\n\r\n//$(\"nav\").hide();         // jquery esconde o nav\r\nconst diferenca = _.difference(\r\n  [\"Banana\", \"Maçã\", \"Melão\"],\r\n  [\"Banana\", \"Uva\", \"Pêra\", \"Mamão\"],\r\n);\r\nconsole.log(diferenca);\r\n*/\r\n\n\n//# sourceURL=webpack:///./js/script.js?");

/***/ })

/******/ });