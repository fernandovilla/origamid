//método que vai ocorrer na fase de 'bubble'
export default function outsideClick(element, events, callbackFunction) {
  const html = document.documentElement;
  const outsideAttribute = "data-outside";

  //coloca um attributo no elemento para que o evento 'click' seja incluído apenas uma vez no html
  if (!element.hasAttribute(outsideAttribute)) {
    events.forEach((userEvent) => {
      html.addEventListener(userEvent, handleOutsideClick);
    });

    element.setAttribute(outsideAttribute, "");
  }

  function handleOutsideClick(event) {
    //se o elemento clicado não for o próprio menu ou tens dele...
    if (element.contains(event.target)) {
      element.removeAttribute(outsideAttribute);
      events.forEach((userEvent) => {
        html.removeEventListener(userEvent, handleOutsideClick);
      });
      callbackFunction();
    }
  }
}
