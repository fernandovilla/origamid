import React from 'react';

export const GlobalContext = React.createContext();

export const GlobalStorage = ({ children }) => {
  const [contador, setContador] = React.useState(0);

  function ContaMaisDois() {
    setContador((i) => i + 2);
  }

  return (
    <GlobalContext.Provider
      value={{ nome: 'Fernando Villa', contador, setContador, ContaMaisDois }}
    >
      {children}
    </GlobalContext.Provider>
  );
};
