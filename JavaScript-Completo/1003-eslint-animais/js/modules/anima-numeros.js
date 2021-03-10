export default function initAnimaNumeros() {
  function animaNumeros() {
    const numeros = document.querySelectorAll('[data-numero]');
    numeros.forEach((item) => {
      const total = +item.innerText;
      const incremento = Math.floor(total / 100); //  arredonda para um número inteiro...

      let start = 0;
      const timer = setInterval(() => {
        start += incremento;
        item.innerText = start;

        //  assim que o start for maior que o total, para a animação...
        if (start > total) {
          numeros.innerText = total;
          clearInterval(timer);
        }
      }, 25 * Math.random());
    });
  }

  function handleMutation(mutation) {
    if (mutation[0].target.classList.contains('ativo')) {
      observer.disconnect(); // para a animação...
      animaNumeros();
    }
  }

  const observerTarget = document.querySelector('.numeros');
  const observer = new MutationObserver(handleMutation);
  observer.observe(observerTarget, { attributes: true });
}
