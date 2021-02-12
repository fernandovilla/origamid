function initExemplo1() {
  const doc = fetch("./doc.txt");

  doc
    .then((response) => response.text())
    .then((body) => {
      const conteudoApi = document.querySelector(".conteudo-api");
      conteudoApi.innerText = body;
    });

  console.log(doc);
}

function initExemplo2() {
  const button = document.querySelector("#buscaCep");

  function handlerBuscarCep(event) {
    event.preventDefault();
    const cep = document.querySelector("#cep").value;

    if (cep == "")
    {
      alert("CEP inválido!");
      return;
    }

    buscarCep(cep);  
  }

  button.addEventListener("click", handlerBuscarCep);

  function buscarCep(cep) {
    const url = `http://viacep.com.br/ws/${cep}/json/`;

    const request = fetch(url)
      .then((response) => response.json())
      .then((body) => {
        document.querySelector("#cidade").innerText = body.localidade + "/" + body.uf;

        document.querySelector("#logradouro").innerText = body.logradouro;
      });
  }
}
//initExemplo2();

function initExemplo3(){
  // Utilizando a API https://blockchain.info/ticker
  // retorne no DOM o valor de compra da bitcoins em reais;
  // Atualize o valor a cada 30 segundos;

  const bitcoinDisplay = document.querySelector(".bitcoin");

  fetchBitcoin();

  function fetchBitcoin(){
    bitcoinDisplay.innerText = "Atualizando bitcoin...";
    
    const url = "https://blockchain.info/ticker";
    const request = fetch(url)
      .then(response => response.json())
      .then(bitcoinJson => {
        bitcoinDisplay.innerText = `BitCoin Brasil: ${bitcoinJson.BRL.symbol} ${bitcoinJson.BRL.buy}`;
      });
  }

  setInterval(fetchBitcoin, 5000);

}
//initExemplo3();

function initExemplo4(){
  // Utilizando a api https://api.chucknorris.io/jokes/random
  // retorne uma piada toda vez que clicar em próxima

  const piadaDisplay = document.querySelector('#piada p');
  const btnProxima = document.querySelector('#piada button');

  btnProxima.addEventListener('click', getJoke)

  getJoke();
  setInterval(getJoke, 10000);

  function getJoke(){
    const url = "https://api.chucknorris.io/jokes/random";
    fetch(url)
    .then(response => response.json())
    .then(json => {
      piadaDisplay.innerText = json.value;
    });
  }

  
}
initExemplo4();
