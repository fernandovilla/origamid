const venom = require('venom-bot');

venom
  .create()
  .then((client) => start(client))
  .catch((erro) => console.log("Deu erro: " + erro));

function start(client){
  console.log("- O venom foi iniciado com sucesso!");

  client.onMessage((message) => {
    if (message.body === 'Oi!'){
      client
        .sendText(message.from, 'Bem vindo!')
        .catch((erro) => {
          console.error('Erro ao enviar mensagem', erro);
        })
    }
  });
}

