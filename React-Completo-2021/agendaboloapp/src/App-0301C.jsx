import React from 'react';
import Produto from './Form/Produtos0301C/Produto';
import HeaderMenu0301C from './HeaderMenu0301C';

const buttons = [
  {
    display: 'Tablet',
    api: 'tablet',
    url: 'https://ranekapi.origamid.dev/json/api/produto/tablet',
  },
  {
    display: 'SmartPhone',
    api: 'smartphone',
    url: 'https://ranekapi.origamid.dev/json/api/produto/smartphone',
  },
  {
    display: 'Notebook',
    api: 'notebook',
    url: 'https://ranekapi.origamid.dev/json/api/produto/notebook',
  },
];

const App = () => {
  const [produto, setProduto] = React.useState(null);
  const [button, setButton] = React.useState('');
  const [buscando, setBuscando] = React.useState(false);

  React.useEffect(() => {
    if (button === null || button === '') return;
    const buttonFind = buttons.find((i) => i.api === button);
    fetchProduto(buttonFind.url);
  }, [button]);

  const fetchProduto = async (url) => {
    setBuscando(true);
    setProduto(null);

    const response = await fetch(url);
    if (response.ok) {
      const json = await response.json();
      setProduto(json);
    } else {
      setProduto(null);
    }

    setBuscando(false);
  };

  return (
    <div>
      <HeaderMenu0301C buttons={buttons} setButton={setButton} />
      {buscando && <p>Buscando produto...</p>}
      {!buscando && produto && <Produto produto={produto} />}
    </div>
  );
};

export default App;
