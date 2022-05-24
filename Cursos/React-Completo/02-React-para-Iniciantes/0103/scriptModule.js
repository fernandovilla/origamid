import { areaQuadrado, perimetroQuadrado } from './quadrado.js';
console.log('Area quadrado:', areaQuadrado(3));
console.log('Perímetro quedrado:', perimetroQuadrado(3));

// Como 'numeroAleatorio.js' exporta apenas uma função, não é necessária a desestruturação
import getNumeroAleatorio from './numeroAleatorio.js';
console.log('Número Aleatório:', getNumeroAleatorio());

// Usar a exportação como um objeto, muito utilizado
import retangulo from './retangulo.js';
console.log('Area Retângulo:', retangulo.calcularArea(4, 3));
console.log('Perímero Retângulo:', retangulo.calcularPerimetro(4, 3));
