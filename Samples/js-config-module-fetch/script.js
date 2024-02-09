import configServer, { getServerAPI } from './config/Config.js';

// console.log(await config.getServerName());
// console.log(await config.getURL());

//console.log(getServerName());
//console.log(config.a());

var serverConfig = await getServerAPI();

console.log('Name:', serverConfig.name);
console.log('URL:', serverConfig.url);

var headers = {};

fetch('http://localhost:81/api/v1/ingredientes', {
  method: 'GET',
  mode: 'cors',
  headers: headers,
})
  .then((response) => {
    if (!response.ok) {
      throw new Erros('Deu erro 1');
    } else {
      return response.json();
    }
  })
  .then((json) => console.log('Ok', json))
  .catch((erro) => {
    console.log('Deu erro 2: ', erro);
  });
