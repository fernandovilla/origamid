import React from 'react';
import { GlobalContext } from '../../GlobalContext';

const Protuto = () => {
  const global = React.useContext(GlobalContext);
  return (
    <div>
      <p> Produto: {global.nome}</p>
      <button onClick={() => global.setContar((c) => c + 1)}>
        {global.contar}
      </button>
    </div>
  );
};

export default Protuto;
