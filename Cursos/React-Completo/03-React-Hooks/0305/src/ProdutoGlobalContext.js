import React from 'react';
import { GlobalContext } from './GlobalContext';

const ProdutoGlobalContext = () => {
  const context = React.useContext(GlobalContext);
  return (
    <div>
      <p>Nome: {context.nome}</p>
      <p>{context.contador}</p>
      <button
        onClick={() => context.setContador((i) => i + 1)}
        style={{ margin: '2px' }}
      >
        +1
      </button>
      <button onClick={context.ContaMaisDois} style={{ margin: '2px' }}>
        +2
      </button>
      <button onClick={() => context.setContador(0)} style={{ margin: '2px' }}>
        Reset
      </button>
    </div>
  );
};

export default ProdutoGlobalContext;
