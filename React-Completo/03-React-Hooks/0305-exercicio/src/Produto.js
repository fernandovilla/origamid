import React from 'react';
import { GlobalContext } from './GlobalContext';

const listarProdutos = (produtos) => {
  if (produtos === null) {
    return <p>Nenhum produto selecionado...</p>;
  }

  return (
    <ul>
      {produtos.map((prod) => (
        <li key={prod.id}>
          {prod.nome}, R$: {prod.preco}
        </li>
      ))}
    </ul>
  );
};

const Produto = () => {
  const context = React.useContext(GlobalContext);

  return (
    <div>
      <h2>Produtos:</h2>
      {listarProdutos(context.produtos)}
    </div>
  );
};

export default Produto;
