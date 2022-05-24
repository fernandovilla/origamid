const li = Array.from(document.querySelectorAll("li"));

// Função convencional, sem uso de currying
// const getElementAttribute = (el, key) => {
//   return el.getElementAttribute(key);
// }

// Função usando currying
// const getElementAttribute = (key) => {
//   return function (el) {
//     return el.getAttribute(key);
//   };
// };

// Função usando currying simplificada
const getElementAttribute = (key) => (el) => el.getAttribute(key);

const getAttributeDataSlide = getElementAttribute('data-slide');
const getAttributeId = getElementAttribute('id');

const dataSlideList = li.map(getAttributeDataSlide);
const idList = li.map(getAttributeId);

console.log(dataSlideList);
console.log(idList);
