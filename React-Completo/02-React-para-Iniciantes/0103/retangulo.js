function calcularArea(base, altura) {
  return base * altura;
}

function calcularPerimetro(base, altura) {
  return base * 2 + altura * 2;
}

const retangulo = {
  calcularArea,
  calcularPerimetro,
};

export default retangulo;
