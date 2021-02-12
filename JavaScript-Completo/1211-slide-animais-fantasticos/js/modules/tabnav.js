import initAnimaNumeros from "./anima-numeros";

export default class TabNav {
  constructor(menu, content) {
    this.tabMenu = document.querySelectorAll(menu);
    this.tabContent = document.querySelectorAll(content);
    this.activeClass = "ativo";
  }

  //ativa a tab conforme o indice da mesma...
  activeTab(index) {
    this.tabContent.forEach((section) => {
      section.classList.remove(this.activeClass);
    });
    const direcao = this.tabContent[index].dataset.anime;
    this.tabContent[index].classList.add(this.activeClass, direcao);
  }

  // adicioma os events às tabs...
  addTabNavEvents() {
    this.tabMenu.forEach((itemMenu, index) => {
      itemMenu.addEventListener("click", () => this.activeTab(index));
    });
  }

  init() {
    if (this.tabMenu.length && this.tabContent.length) {
      //  ativar o primeiro item...
      this.activeTab(0);
      //  adcionar os eventos...
      this.addTabNavEvents();
    }
    return this;
  }
}

// export default function initTabNav() {
//   const tabMenu = document.querySelectorAll('[data-tab="menu"] li');
//   const tabContent = document.querySelectorAll('[data-tab="content"] section');

//   function activeTab(index) {
//     tabContent.forEach((section) => {
//       section.classList.remove('ativo');
//     });
//     const direcao = tabContent[index].dataset.anime;
//     tabContent[index].classList.add('ativo', direcao);
//   }

//   if (tabMenu.length && tabContent.length) {
//     tabContent[0].classList.add('ativo');
//     tabMenu.forEach((itemMenu, index) => {
//       itemMenu.addEventListener('click', () => {
//         activeTab(index);
//       });
//     });
//   }
// }
