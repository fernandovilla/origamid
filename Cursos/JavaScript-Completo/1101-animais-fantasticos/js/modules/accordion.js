export default class Accordion {
  constructor(list) {
    this.accordionList = document.querySelectorAll(list);
    this.activeClass = "ativo";
  }

  toggleAccordion(item) {
    item.classList.toggle(this.activeClass);
    item.nextElementSibling.classList.toggle(this.activeClass);
  }

  //  adiciona os events ao 'accordion'
  addAccordionEvent() {
    this.accordionList.forEach((item) => {
      item.addEventListener("click", () => {
        this.toggleAccordion(item);
      });
    });
  }

  //  iniciar função
  init() {
    if (this.accordionList.length) {
      //  deixa o primeiro item ativo
      this.toggleAccordion(this.accordionList[0]);
      //  adiciona os eventos
      this.addAccordionEvent();
    }
    return this;
  }
}

// export default function initAccordion() {
//   const accordionList = document.querySelectorAll('[data-anime="accordion"] dt');
//   const activeClass = 'ativo';

//   function activeAccordion() {
//     this.classList.toggle(activeClass);
//     this.nextElementSibling.classList.toggle(activeClass);
//   }

//   if (accordionList.length) {
//     accordionList[0].classList.add(activeClass);
//     accordionList[0].nextElementSibling.classList.add(activeClass);

//     accordionList.forEach((item) => {
//       item.addEventListener('click', activeAccordion);
//     });
//   }
// }
