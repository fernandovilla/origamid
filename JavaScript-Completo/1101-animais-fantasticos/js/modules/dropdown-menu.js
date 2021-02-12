import initFuncionamento from './funcionamento.js';
import outsideClick from './outsideclick.js';

export default class DropdownMenu {
  constructor(dropdownMenus, events){
    this.dropdownMenus = document.querySelectorAll(dropdownMenus);
    this.activeDropdownMenu = this.activeDropdownMenu.bind(this);
    this.activeClass = 'active';

    if (events === undefined){
      this.events = ['touchstart', 'click'];
    } else {
      this.events = events;
    }
  }

  //  ativa o dropdownmenu e adiciona a função que observa o click fora dele
  activeDropdownMenu(event) {
    event.preventDefault();
    const element = event.currentTarget;
    element.classList.add(this.activeClass);
    outsideClick(element, this.events, () => {
      element.classList.remove(this.activeClass);
    });
  }

  //  adiciona os events ao dropdownMenu
  addDropdownMenusEvents(){
    this.dropdownMenus.forEach((menu) => {
      this.events.forEach((userEvent) => {
        menu.addEventListener(userEvent, this.activeDropdownMenu);
      });
    });
  }

  init(){
    if (this.dropdownMenus.lenght){
      this.addDropdownMenusEvents();
    }
    return this;
  }
}
