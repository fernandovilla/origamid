import React from 'react';
import { GlobalContext } from '../../GlobalContext0305Ex';

const Produto = () => {
  const global = React.useContext(GlobalContext);
  console.log(global);
  return (
    <div>
      Produtos:
      {global.dados && (
        <ul>
          {global.dados.map((dado, index) => (
            <li key={index}>{dado.nome}</li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default Produto;
