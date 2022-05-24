import ReactDOM from 'react-dom';
import React from 'react';
import App from './App';

/************************************************************
  1º argumento: aplicação que será carregada = > <App /> -> /src/App.js
  2º argumento: elemento que a aplicação será renderizada => index.html -> <div id='root'>
*************************************************************/
ReactDOM.render(<App />, document.getElementById('root'));
