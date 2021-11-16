import React from 'react';
import { GlobalStorage } from './GlobalContext0305Ex';
import Produto from './Form/Produtos0305/Produto0305Ex';
import Limpar from './Limpar';

const App = () => {
  return (
    <div>
      <GlobalStorage>
        <Produto />
        <Limpar />
      </GlobalStorage>
    </div>
  );
};

export default App;
