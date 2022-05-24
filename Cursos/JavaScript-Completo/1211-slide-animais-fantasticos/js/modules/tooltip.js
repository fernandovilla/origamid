export default class Tooltip {
  constructor(tooltips) {
    this.tooltips = document.querySelectorAll(tooltips);

    //  bind do objeto da classe aos callbacks, diz para o callback que a classe é o 'this'
    this.onMouseLeave = this.onMouseLeave.bind(this);
    this.onMouseMove = this.onMouseMove.bind(this);
    this.onMouseOver = this.onMouseOver.bind(this);
  }

  onMouseMove(event) {
    this.tooltipBox.style.top = `${event.pageY + 20}px`;
    if (event.pageX + 200 > window.innerWidth) {
      this.tooltipBox.style.left = `${event.pageX - 180}px`;
    } else {
      this.tooltipBox.style.left = `${event.pageX + 15}px`;
    }
  }

  onMouseLeave(event) {
    this.tooltipBox.remove();
    event.currentTarget.removeEventListener("mouseleave", this.onMouseLeave);
    event.currentTarget.removeEventListener("mousemove", this.onMouseMove);
  }

  //  Cria a tooltip box e coloca ela no body
  criarTooltipBox(element) {
    const tooltipBox = document.createElement("div");
    const text = element.getAttribute("aria-label");
    tooltipBox.classList.add("tooltip");
    tooltipBox.innerText = text;
    document.body.appendChild(tooltipBox);
    this.tooltipBox = tooltipBox;
  }

  onMouseOver(event) {
    //  cria a tooltipbox e a coloca em uma propriedade da classe
    this.criarTooltipBox(event.currentTarget);
    //  adiciona os eventos à tooltipbox
    event.currentTarget.addEventListener("mousemove", this.onMouseMove);
    event.currentTarget.addEventListener("mouseleave", this.onMouseLeave);
  }

  addTooltipEvents() {
    this.tooltips.forEach((item) => {
      item.addEventListener("mouseover", this.onMouseOver);
    });
  }

  init() {
    if (this.tooltips.length) {
      this.addTooltipEvents();
    }

    return this;
  }
}

// export default function initTooltip() {
//   const tooltips = document.querySelectorAll('[data-tooltip]');

//   const onMouseMove = {
//     handleEvent(event) {
//       this.tooltipBox.style.top = `${event.pageY + 20}px`;
//       this.tooltipBox.style.left = `${event.pageX + 20}px`;
//     },
//   };

//   const onMouseLeave = {
//     handleEvent() {
//       this.tooltipBox.remove();
//       this.element.removeEventListener('mouseleave', onMouseLeave);
//       this.element.removeEventListener('mousemove', onMouseMove);
//     },
//   };

//   function criarTooltipBox(element) {
//     const tooltipBox = document.createElement('div');
//     const text = element.getAttribute('aria-label');
//     tooltipBox.classList.add('tooltip');
//     tooltipBox.innerText = text;
//     document.body.appendChild(tooltipBox);
//     return tooltipBox;
//   }

//   function onMouseOver() {
//     const tooltipBox = criarTooltipBox(this);

//     onMouseMove.tooltipBox = tooltipBox;
//     this.addEventListener('mousemove', onMouseMove);

//     onMouseLeave.tooltipBox = tooltipBox;
//     onMouseLeave.element = this;
//     this.addEventListener('mouseleave', onMouseLeave);
//   }

//   tooltips.forEach((item) => {
//     item.addEventListener('mouseover', onMouseOver);
//   });
// }
