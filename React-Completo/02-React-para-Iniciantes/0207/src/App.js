import React from 'react';

const luana = {
  cliente: 'Luana',
  idade: 27,
  compras: [
    { nome: 'Notebook', preco: 'R$ 2500' },
    { nome: 'Geladeira', preco: 'R$ 3000' },
    { nome: 'Smartphone', preco: 'R$ 1500' },
  ],
  ativa: true,
};

const mario = {
  cliente: 'Mário',
  idade: 31,
  compras: [
    { nome: 'Notebook', preco: 'R$ 2500' },
    { nome: 'Geladeira', preco: 'R$ 3000' },
    { nome: 'Smartphone', preco: 'R$ 1500' },
    { nome: 'Guitarra', preco: 'R$ 3500' },
  ],
  ativa: false,
};

const App = () => {
  const dados = luana;

  // let totalGasto = 0;
  // dados.compras.forEach((item) => {
  //   totalGasto += Number(item.preco.replace('R$ ', ''));
  // });

  const totalGasto = dados.compras
    .map((item) => {
      return Number(item.preco.replace('R$ ', ''));
    })
    .reduce((a, b) => {
      return a + b;
    });

  return (
    <div>
      <p>Nome: {dados.cliente}</p>
      <p>Idade: {dados.idade}</p>
      <p>
        Situação:{' '}
        <span style={{ color: dados.ativa ? 'green' : 'red' }}>
          {dados.ativa ? 'Ativa' : 'Inativa'}
        </span>
      </p>
      <p>Total Gasto: R$ {totalGasto} </p>
      {totalGasto > 10000 && <p>Você está gastando demais!</p>}
    </div>
  );
};

export default App;
