/*Arrow Function */

const imgs = document.querySelectorAll("img");
imgs.forEach((item) => {
  console.log(item);
});

document.querySelectorAll("p").forEach((item, index) => {
  console.log(`p[${index}] => ${item.innerText}`);
});
