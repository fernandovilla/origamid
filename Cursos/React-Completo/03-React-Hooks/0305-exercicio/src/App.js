import React from 'react';
import BotaoLimpar from './BotaoLimpar';
import { GlobalStorage } from './GlobalContext';
import Produto from './Produto';

const App = () => {
  return (
    <GlobalStorage>
      <Produto />
      <BotaoLimpar />
    </GlobalStorage>
  );
};

export default App;
