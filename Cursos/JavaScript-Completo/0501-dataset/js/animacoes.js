function initTabNav() {
  const tabMenu = document.querySelectorAll("[data-tab='menu'] > li");
  const tabContent = document.querySelectorAll(
    "[data-tab='content'] > section",
  );

  if (tabMenu.length && tabContent.length) {
    function activeTab(index) {
      tabContent.forEach((section) => {
        section.classList.remove('ativo');
      });

      const direcao = tabContent[index].dataset.anime;
      tabContent[index].classList.add('ativo', direcao);
    }

    tabMenu.forEach((itemMenu, index) => {
      itemMenu.addEventListener('click', () => {
        activeTab(index);
      });
    });
  }
}
initTabNav();
/*************************************************************/

function initAccordion() {
  const ativoClass = 'ativo';
  function activeAccordion(event) {
    //this representa o item que eu estou clicando...
    this.classList.toggle(ativoClass);
    this.nextElementSibling.classList.toggle(ativoClass);
  }

  const accordionList = document.querySelectorAll(
    '[data-anime="accordion"] dt',
  );
  if (accordionList.length) {
    accordionList.forEach((item) => {
      item.addEventListener('click', activeAccordion);
    });
  }
}
initAccordion();
/*************************************************************/

function initScrollSuave() {
  function scrollToSection(event) {
    event.preventDefault();
    const href = event.currentTarget.getAttribute('href');
    const section = document.querySelector(href);

    section.scrollIntoView({
      behavior: 'smooth',
      block: 'start',
    });

    /* Forma alternativa...
      window.scrollTo({
        top: section.offsetTop,
        behavior: "smooth",
      });
  */
  }

  const linksInternos = document.querySelectorAll(
    '[data-menu="suave"] a[href^="#"]',
  );
  linksInternos.forEach((link) => {
    link.addEventListener('click', scrollToSection);
  });
}
initScrollSuave();
/*************************************************************/

function initAnimacaoScroll() {
  const sections = document.querySelectorAll('[data-anime="scroll"]');

  if (sections.length) {
    const halfHeightWindow = window.innerHeight * 0.6;

    function animaScroll() {
      sections.forEach((section) => {
        const sectionTop = section.getBoundingClientRect().top;
        const ativo = sectionTop - halfHeightWindow < 0;

        if (ativo) {
          section.classList.add('ativo');
        } else {
          section.classList.remove('ativo');
        }
      });
    }

    animaScroll(); //executa uma vez para carregar a primeira section do site
    window.addEventListener('scroll', animaScroll);
  }
}
initAnimacaoScroll();
/*************************************************************/
