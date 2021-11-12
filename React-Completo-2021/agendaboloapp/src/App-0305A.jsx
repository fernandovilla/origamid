import React from 'react';
import UserContext from './UserContext';
import Produto from './Form/Produtos0305/Produto';

const App = () => {
  console.log(UserContext);

  return (
    <UserContext.Provider value={{ nome: 'Caneta Esferográfica BIQ' }}>
      <h1>0305 - useContext</h1>
      <Produto />
    </UserContext.Provider>
  );
};

export default App;
