import React from 'react';
import { GlobalContext } from './GlobalContext';

const BotaoLimpar = () => {
  const context = React.useContext(GlobalContext);
  return <button onClick={context.limparProdutos}>Limpar</button>;
};

export default BotaoLimpar;
