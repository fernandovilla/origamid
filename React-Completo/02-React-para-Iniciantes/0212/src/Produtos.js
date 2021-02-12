import React from 'react';
import Produto from './Produto';
import Title from './Title';

const Produtos = () => {
  const produtos = [
    { nome: 'Notebook', propriedades: ['16gb ram', '512gb'] },
    { nome: 'Smartphone', propriedades: ['2gb ram', '128gb'] },
  ];

  return (
    <section>
      <Title texto="Produtos" />
      {produtos.map((prod) => (
        <Produto key={prod.nome} produto={prod} />
      ))}
    </section>
  );
};

export default Produtos;
