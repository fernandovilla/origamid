import React from 'react';
import Produto from './Produto';
import ProdutoGlobal from './ProdutoGlobalContext';
import UserContext from './UserContext';
import { GlobalStorage } from './GlobalContext';

const Sample1 = () => {
  return (
    <UserContext.Provider value={{ nome: 'Fernando' }}>
      <Produto />
    </UserContext.Provider>
  );
};

const Sample2 = () => {
  return (
    <GlobalStorage>
      <ProdutoGlobal />
    </GlobalStorage>
  );
};

const App = () => {
  return Sample2();
};

export default App;
