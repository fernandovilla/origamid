function initTabNav() {
  const tabMenu = document.querySelectorAll(".js-tabmenu > li");
  const tabContent = document.querySelectorAll(".js-tabcontent > section");

  if (tabMenu.length && tabContent.length) {
    function activeTab(index) {
      tabContent.forEach((section) => {
        section.classList.remove("ativo");
      });

      tabContent[index].classList.add("ativo");
    }

    tabMenu.forEach((itemMenu, index) => {
      itemMenu.addEventListener("click", () => {
        activeTab(index);
      });
    });
  }
}
initTabNav();
/******************************************/

function initAccordion() {
  const ativoClass = "ativo";
  function activeAccordion(event) {
    //this representa o item que eu estou clicando...
    this.classList.toggle(ativoClass);
    this.nextElementSibling.classList.toggle(ativoClass);
  }

  const accordionList = document.querySelectorAll(".js-accordion dt");
  if (accordionList.length) {
    accordionList.forEach((item) => {
      item.addEventListener("click", activeAccordion);
    });
  }
}
initAccordion();
