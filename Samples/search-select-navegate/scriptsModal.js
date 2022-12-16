const modal = document.querySelector('.modal');
const modalButtonOpen = document.querySelector('.modal-button');
const modalButtonClose = document.querySelector('.head i');
const modalContent = modal.querySelector('.modal-content');

const modalAtivo = () => modal.classList.contains('active');

const Show = () => modal.classList.add('active');
const Close = () => modal.classList.remove('active');

modalButtonOpen.addEventListener('click', Show, false);

modalButtonClose.addEventListener('click', Close, false);

modal.addEventListener(
  'click',
  (event) => {
    var areaContent = modalContent.getBoundingClientRect();
    var x = event.clientX;
    var y = event.clientY;

    var clicouDentro =
      x >= areaContent.left &&
      x <= areaContent.right &&
      y >= areaContent.top &&
      y <= areaContent.bottom;

    if (!clicouDentro) Close();
  },
  false,
);

window.addEventListener(
  'keyup',
  (event) => {
    if (event.keyCode === 27 && modalAtivo()) {
      Close();
    }
  },
  false,
);
