import configServer, { getServerAPI } from './config/Config.js';

// console.log(await config.getServerName());
// console.log(await config.getURL());

//console.log(getServerName());
//console.log(config.a());

var serverConfig = await getServerAPI();

console.log('Name:', serverConfig.name);
console.log('URL:', serverConfig.url);
