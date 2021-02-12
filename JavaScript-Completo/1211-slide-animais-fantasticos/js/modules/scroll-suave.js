export default class ScrollSuave {
  constructor(links, options) {
    this.linksInternos = document.querySelectorAll(links);
    if (options === undefined) {
      this.options = { behavior: "smooth", block: "start" };
    } else {
      this.options = options;
    }

    //  força a definição do 'this' usando o 'bind()'
    this.scrollToSection = this.scrollToSection.bind(this);
  }

  scrollToSection(event) {
    event.preventDefault();
    const href = event.currentTarget.getAttribute("href");
    const section = document.querySelector(href);
    section.scrollIntoView(this.options);
  }

  addLinkEvent() {
    this.linksInternos.forEach((link) => {
      link.addEventListener("click", this.scrollToSection);
    });
  }

  init() {
    if (this.linksInternos.length) {
      this.addLinkEvent();
    } else {
      console.log("vazio!");
    }
    return this;
  }
}

// export default function initScrollSuave() {
//   const linksInternos = document.querySelectorAll('[data-menu="suave"] a[href^="#"]');

//   function scrollToSection(event) {
//     event.preventDefault();
//     const href = event.currentTarget.getAttribute('href');
//     const section = document.querySelector(href);
//     section.scrollIntoView({
//       behavior: 'smooth',
//       block: 'start',
//     });
//   }

//   linksInternos.forEach((link) => {
//     link.addEventListener('click', scrollToSection);
//   });
// }
