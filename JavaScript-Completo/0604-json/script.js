function initExemplo1() {
  const doc = fetch("./cursos.txt")
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
    });
}
//initExemplo1();

//Deserialização de Json
function initExemplo2() {
  const doc = fetch("./cursos.txt")
    .then((response) => response.text())
    .then((jsonText) => {
      console.log(jsonText);
      const json = JSON.parse(jsonText);

      console.log(json);
    });
}
//initExemplo2();

//Serialização de Json
function initExemplo3(){
  const settings = {
    player: "Google",
    tempo: 25.5,
    aula: "2.1 JavaScript"
  }

  const jsonSettings = JSON.stringify(settings);
  console.log(jsonSettings);

  localStorage.settings = jsonSettings;
  console.log(JSON.parse(localStorage.settings));
}
initExemplo3();