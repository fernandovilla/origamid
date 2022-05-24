import debounce from './debounce.js';

export default class ScrollAnima {
  constructor(sections) {
    this.sections = document.querySelectorAll(sections);
    this.windowMetade = window.innerHeight * 0.6;
    
    //this.checkDistance = this.checkDistance.bind(this);
    this.checkDistance = debounce(this.checkDistance.bind(this), 20);
  }

  getDistance() {
    // desestrutura o this.sections (pois ele é NodeList e não Array)
    //Usa o map, ao invés do forEach, pois o map dá um retorno
    this.distance = [...this.sections].map((section) => {
      const offset = section.offsetTop;
      return {
        element: section,
        offset: Math.floor(offset - this.windowMetade),
      };
    });
  }

  checkDistance() {
    this.distance.forEach((item) => {
      if (window.pageYOffset > item.offset) {
        item.element.classList.add("ativo");
      } else if (item.element.classList.contains("ativo")) {
        item.element.classList.remove("ativo");
      }
    });
  }

  init() {
    if (this.sections.length) {
      this.getDistance();
      this.checkDistance();
      window.addEventListener("scroll", this.checkDistance);
    }
    return this;
  }

  stop() {
    window.removeEventListener("scroll", this.checkDistance);
  }
}

// export default function initAnimacaoScroll() {
//   const sections = document.querySelectorAll('[data-anime="scroll"]');
//   const windowMetade = window.innerHeight * 0.6;

//   function animaScroll() {
//     sections.forEach((section) => {
//       const sectionTop = section.getBoundingClientRect().top;
//       const isSectionVisible = sectionTop - windowMetade < 0;
//       if (isSectionVisible) {
//         section.classList.add("ativo");
//       } else if (section.classList.contains("ativo")) {
//         section.classList.remove("ativo");
//       }
//     });
//   }
//   if (sections.length) {
//     animaScroll();
//     window.addEventListener("scroll", animaScroll);
//   }
// }
