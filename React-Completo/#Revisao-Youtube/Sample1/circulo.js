import getNumeroAleatorio from './numeroAleatorio.js';

function area(raio) {
  return Math.PI * raio * raio;
}

function circunferencia(raio) {
  return 2 * raio * Math.PI;
}

function numeroAleatorio() {
  return getNumeroAleatorio();
}

const circulo = {
  calcularArea: area,
  calcularCircunferencia: circunferencia,
  obterNumeroAleatorio: numeroAleatorio,
};

export default circulo;
