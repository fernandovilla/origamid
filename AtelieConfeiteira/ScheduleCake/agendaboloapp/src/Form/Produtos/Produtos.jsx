import React from 'react';
import Titulo from '../../Titulo';
import Produto from './Produto';

const produtos = [
  { nome: 'Notebook', propriedades: ['16gb RAM', '512gb HD'] },
  { nome: 'Smartphone', propriedades: ['2gb RAM', '128gb SD'] },
];

const Produtos = () => {
  return (
    <>
      <Titulo texto="Produtos" />
      {produtos.map((prod) => (
        <Produto key={prod.nome} {...prod} />
      ))}
    </>
  );
};

export default Produtos;
