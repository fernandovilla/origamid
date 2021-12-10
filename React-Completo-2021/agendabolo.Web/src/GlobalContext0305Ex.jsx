import React from 'react';

export const GlobalContext = React.createContext();

export const GlobalStorage = ({ children }) => {
  const [dados, setDados] = React.useState(null);

  React.useEffect(() => buscarProduto(), []);

  const buscarProduto = async () => {
    var response = await fetch(
      'https://ranekapi.origamid.dev/json/api/produto/',
    );
    var json = await response.json();
    setDados(json);
  };

  const limparDados = () => {
    console.log('Limpando...');
    setDados(null);
  };

  return (
    <GlobalContext.Provider value={{ dados, limparDados }}>
      {children}
    </GlobalContext.Provider>
  );
};
