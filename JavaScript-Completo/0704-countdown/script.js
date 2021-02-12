import Countdown from "./Countdown.js";

setInterval(() => {
  const tempoParaONatal = new Countdown("24 December 2020 23:59:59 GMT-0300");
  console.log(tempoParaONatal.total);

  const tempoParaOAnoNovo = new Countdown("31 December 2020 23:59:59 GMT-0300");
  console.log(tempoParaOAnoNovo.total);

  const tempoParaMeuNiver = new Countdown("02 June 2021 05:00:00 GMT-0300");
  console.log(tempoParaMeuNiver.total);

  console.log("--------------------------------------------------");
}, 5000);
