const controles = document.querySelector('#controles');
const cssText = document.querySelector('.css');
const btn = document.querySelector('.btn');

controles.addEventListener('change', handleChanges);

function handleChanges(event) {
  const target = event.target;
  const name = target.name;
  const value = target.value;

  handleStyle[name](value);

  saveValues(name, value);
  showCss();
}

const handleStyle = {
  element: btn,
  texto(value) {
    console.log(value);
    this.element.innerText = value;
  },
  color(value) {
    this.element.style.color = value;
  },
  backgroundColor(value) {
    this.element.style.backgroundColor = value;
  },
  height(value) {
    this.element.style.height = value + 'px';
  },
  width(value) {
    this.element.style.width = value + 'px';
  },
  border(value) {
    this.element.style.border = value;
  },
  borderRadius(value) {
    this.element.style.borderRadius = value + 'px';
  },
  fontFamily(value) {
    this.element.style.fontFamily = value;
  },
  fontSize(value) {
    this.element.style.fontSize = value + 'rem';
  },
};

function showCss() {
  cssText.innerHTML =
    '<span>' + btn.style.cssText.split(' ').join(';</span><span>');
}

function saveValues(name, value) {
  localStorage[name] = value;
}

function loadValues() {
  //Obtém todas as propriedades salvas no LocalStorage do browser;
  const properties = Object.keys(localStorage);

  properties.forEach((prop) => {
    handleStyle[prop](localStorage[prop]);
    controles.elements[prop].value = localStorage[prop];
  });
  showCss();
}
loadValues();
