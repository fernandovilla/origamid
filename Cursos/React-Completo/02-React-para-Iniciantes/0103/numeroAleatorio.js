// Exporta apenas essa função
export default function getNumeroAleatorio() {
  return obterNumeroAleatorio();
}

export function obterNumeroAleatorio() {
  return Math.random();
}
