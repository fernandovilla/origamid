class SmoothScroll {
  constructor(links) {
    this.linkElements = document.querySelectorAll(links);

    this.addClickEvent();
  }

  handleClick(event) {
    event.preventDefault();
    const href = event.currentTarget.getAttribute('href');
    const section = document.querySelector(href);

    const arg = {
      top: section.offsetTop - (window.innerHeight - section.clientHeight) / 2,
      behavior: 'smooth',
    };

    window.scrollTo(arg);
  }

  addClickEvent() {
    this.linkElements.forEach((link) => {
      link.addEventListener('click', this.handleClick);
    });
  }
}

class ActiveSmoothScroll extends SmoothScroll {
  constructor(links, sections) {
    super(links);

    this.sectionElements = document.querySelectorAll(sections);

    // Força o this ser a classe, e não o elemento que a função callback está rodando no evento, no caso 'window';
    this.handleScroll = this.handleScroll.bind(this);

    // Executa na inicialização do objeto para já pintar o link
    this.handleScroll();

    this.activeNavScroll();
  }

  handleScroll(event) {
    this.sectionElements.forEach((section, index) => {
      if (window.pageYOffset > section.offsetTop - window.innerHeight * 0.5) {
        this.linkElements[index].classList.add('active');
      } else {
        this.linkElements[index].classList.remove('active');
      }
    });
  }

  activeNavScroll() {
    // Terá que usar o bind, senão o this da função callback será 'window', a não ser que seja usada uma arrow function;
    window.addEventListener('scroll', this.handleScroll);
  }
}

const scroll = new ActiveSmoothScroll("a[href^='#']", 'section');
console.log(scroll.linkElements);
