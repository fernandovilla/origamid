export default class Modal {
  constructor(botaoAbrir, botaoFechar, containerModal) {
    this.botaoAbrir = document.querySelector(botaoAbrir);
    this.botaoFechar = document.querySelector(botaoFechar);
    this.containerModal = document.querySelector(containerModal);

    //  bind this ao callback para fazer referência ao objeto da classe
    this.eventToggleModal = this.eventToggleModal.bind(this);
    this.cliqueForaModal = this.cliqueForaModal.bind(this);
  }

  //  abre ou fecha o modal
  toggleModal(event) {
    this.containerModal.classList.toggle("ativo");
  }

  eventToggleModal(event) {
    event.preventDefault();
    this.toggleModal(event);
  }

  //  fecha o modal ao clicar fora do container
  cliqueForaModal(event) {
    if (event.target === this.containerModal) {
      this.toggleModal();
    }
  }

  addModalEvents() {
    this.botaoAbrir.addEventListener("click", this.eventToggleModal);
    this.botaoFechar.addEventListener("click", this.eventToggleModal);
    this.containerModal.addEventListener("click", this.cliqueForaModal);
  }

  init() {
    if (this.botaoAbrir && this.botaoFechar && this.containerModal) {
      this.addModalEvents();
    }
    return this;
  }
}

// export default function initModal() {
//   const botaoAbrir = document.querySelector('[data-modal="abrir"]');
//   const botaoFechar = document.querySelector('[data-modal="fechar"]');
//   const containerModal = document.querySelector('[data-modal="container"]');

//   function toggleModal(event) {
//     event.preventDefault();
//     containerModal.classList.toggle('ativo');
//   }

//   function cliqueForaModal(event) {
//     if (event.target === this) {
//       toggleModal(event);
//     }
//   }

//   if (botaoAbrir && botaoFechar && containerModal) {
//     botaoAbrir.addEventListener('click', toggleModal);
//     botaoFechar.addEventListener('click', toggleModal);
//     containerModal.addEventListener('click', cliqueForaModal);
//   }
// }
