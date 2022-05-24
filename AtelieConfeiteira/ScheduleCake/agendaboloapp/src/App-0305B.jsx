import React from 'react';
import { GlobalStorage } from './GlobalContext';
import Produto2 from './Form/Produtos0305/Protuto2';

const App = () => {
  return (
    <>
      <GlobalStorage>
        <Produto2 />
      </GlobalStorage>
    </>
  );
};

export default App;
