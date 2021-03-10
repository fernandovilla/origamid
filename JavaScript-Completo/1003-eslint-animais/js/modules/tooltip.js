export default function initTooltip() {
  const tooltips = document.querySelectorAll('[data-tooltip]');

  if (tooltips) {
    const onMouseLeave = {
      tooltipbox: '',
      element: '',
      handleEvent() {
        this.tooltipbox.remove();
        this.element.removeEventListener('mouseleave', onMouseLeave);
        this.element.removeEventListener('mousemove', onMouseMove);
      },
    };

    const onMouseMove = {
      tooltipbox: '',
      handleEvent(event) {
        this.tooltipbox.style.top = event.pageY + 15 + 'px';
        this.tooltipbox.style.left = event.pageX + 12 + 'px';
      },
    };

    function criarTooltipBox(element) {
      const tooltipBox = document.createElement('div');
      const text = element.getAttribute('aria-label');
      tooltipBox.classList.add('tooltip');
      tooltipBox.innerText = text;

      return tooltipBox;
    }

    function onMouseOver(event) {
      const tooltipbox = criarTooltipBox(this); //  this é o elemento que ocorreu o evento

      document.body.appendChild(tooltipbox);
      tooltipbox.style.top = `${event.pageY + 12}px`; //  adiciona mais 15px para o cursor do mouse não ficar sobre o div da tooltip
      tooltipbox.style.left = `${event.pageX + 12}px`;

      onMouseMove.tooltipbox = tooltipbox;
      this.addEventListener('mousemove', onMouseMove);

      onMouseLeave.element = this;
      onMouseLeave.tooltipbox = tooltipbox;
      this.addEventListener('mouseleave', onMouseLeave);
    }

    //function onMouseLeave(event) {}

    tooltips.forEach((item) => {
      item.addEventListener('mouseover', onMouseOver);
    });
  }
}
