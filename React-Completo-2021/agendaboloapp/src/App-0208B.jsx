import React from 'react';

const produtos = [
  {
    id: 1,
    nome: 'Smartphone',
    preco: 'R$ 2000.00',
    cores: ['#29D8D5', '#252A34', '#FC3766'],
  },
  {
    id: 2,
    nome: 'Notebook',
    preco: 'R$ 3000.00',
    cores: ['#FFD045', '#D4394B', '#F37C59'],
  },
  {
    id: 3,
    nome: 'Tablet',
    preco: 'R$ 1500.00',
    cores: ['#365069', '#47C1C8', '#F95786'],
  },
];

const listaProdutos = () => {
  return produtos
    .filter(({ preco }) => Number(preco.replace('R$ ', '')) > 1500.0)
    .map(({ id, nome, preco, cores }) => (
      <div key={id}>
        <h1>{nome}</h1>
        <p>Preco: {preco}</p>
        <ul>
          {cores.map((cor) => (
            <li style={{ backgroundColor: cor, color: 'white' }} key={cor}>
              {cor}
            </li>
          ))}
        </ul>
      </div>
    ));
};

const App = () => {
  return <section>{listaProdutos()}</section>;
};

export default App;
