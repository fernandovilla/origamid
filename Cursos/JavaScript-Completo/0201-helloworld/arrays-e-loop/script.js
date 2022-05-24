let games = ["Switch", "PS5", "XBox"];

console.log(games.pop()) //remove o último da lista e retorna...
console.log(games);

games.push("Gameboy") //Adiciona um item na lista...
console.log(games);
console.log("Length: " + games.length);

console.log("\nfor (...)");
for (let i = 0 i < games.length i++) {
  console.log(`\ti => ${i} ${games[i]}`);
}

console.log("\nwhile (...)");
let x = 0;
while (x < games.length) {
  if (games[x] === "Gameboy") break;
  console.log(`\tx => ${x} ${games[x++]}`);
}

console.log("\n>> forEach (...)");
games.forEach(function (item, index, array) {
  console.log(`\t${item} ${index + 1}/${array.length}`);
});
