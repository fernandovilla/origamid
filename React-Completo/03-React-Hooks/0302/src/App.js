import React, { useState } from 'react';
import Produto from './Produto';

// Uso do React.useEffect()
const Sample1 = () => {
  const [count, setCount] = React.useState(0);

  React.useEffect(() => {
    console.log('Executou useEffect()');
  });

  React.useEffect(() => {
    document.title = `Count: ${count}`;
  }, [count]);

  return <button onClick={() => setCount(count + 1)}>{count}</button>;
};

// Uso do React.useEffect com fetch()
const Sample2 = () => {
  const [count, setCount] = React.useState(0);
  const [produto, setProduto] = React.useState(null);
  const url = 'https://ranekapi.origamid.dev/json/api/produto/notebook';

  React.useEffect(() => {
    console.log('Carregando produto...');
    fetch(url)
      .then((responnse) => responnse.json())
      .then((json) => setProduto(json));
    console.log('Produto carregado');
  }, [produto]); // Executado apenas quando [produto] for modificado

  return (
    <div>
      <div>
        {produto && (
          <div>
            <h1>{produto.nome}</h1>
          </div>
        )}
      </div>
      <button onClick={() => setCount(count + 1)}>OK</button>
    </div>
  );
};

// Uso do useEffect, sendo executado em momentos/efeitos diferentes
const Sample3 = () => {
  const [count, setCount] = React.useState(0);
  const [modal, setModal] = React.useState(false);

  React.useEffect(() => {
    document.title = 'Total ' + count;
  }, [count]); //Executado quando o 'count' mudar...

  React.useEffect(() => {
    setCount(0);
  }, [modal]); // Executado quando o 'modal' mudar...

  return (
    <div>
      {modal && <p>Meu modal!</p>}
      <button onClick={() => setModal(!modal)}>Modal</button>
      <hr />
      <button onClick={() => setCount(count + 1)}>{count}</button>
    </div>
  );
};

const Sample4 = () => {
  const [ativo, setAtivo] = React.useState(false);
  return (
    <div>
      <p>Meu App</p>
      <button onClick={() => setAtivo(!ativo)}>Abrir</button>
      {ativo && <Produto />}
    </div>
  );
};

const App = () => {
  return Sample4();
};

export default App;
