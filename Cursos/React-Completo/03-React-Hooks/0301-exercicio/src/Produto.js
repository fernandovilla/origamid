import React from 'react';

const Produto = ({ produto }) => {
  //if (produto === null) return null;

  return (
    <div>
      <h2>{produto.nome}</h2>
      <p>Preço R$: {produto.preco}</p>
      <img src={produto.fotos[0].src} alt={produto.fotos[0].titulo} />
    </div>
  );
};

export default Produto;
