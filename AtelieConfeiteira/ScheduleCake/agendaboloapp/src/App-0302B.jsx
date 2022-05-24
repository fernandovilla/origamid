import React from 'react';
import Produto from './Form/Produtos0301C/Produto';
import HeaderMenu0301C from './HeaderMenu0301C';

const buttons = [
  {
    key: 'notebook',
    display: 'Notebook',
    api: 'https://ranekapi.origamid.dev/json/api/produto/notebook',
  },
  {
    key: 'smartphone',
    display: 'Smartphone',
    api: 'https://ranekapi.origamid.dev/json/api/produto/smartphone',
  },
];

const App = () => {
  const [loading, setLoading] = React.useState(false);
  const [produto, setProduto] = React.useState(null);
  const [pref, setPref] = React.useState(
    window.localStorage.getItem('produto'),
  );

  React.useEffect(() => {
    // rodará para carregar o item gravado no localstorage
    carregarProduto(pref);
  }, []);

  React.useEffect(() => {
    if (pref === null) return;

    // Executará toda vez que o produto for trocado;
    window.localStorage.setItem('produto', pref);
    carregarProduto(pref);
  }, [pref]);

  const handleClick = async (event) => {
    setPref(event.target.id);
  };

  const carregarProduto = async (key) => {
    setLoading(true);
    setProduto(null);

    const b = buttons.find((b) => b.key === key);

    if (b === undefined) {
      setLoading(false);
      return;
    }

    const response = await fetch(b.api);
    const json = await response.json();
    setProduto(json);
    setLoading(false);
  };

  return (
    <div>
      <h1>Preferência: {pref} </h1>
      <HeaderMenu0301C buttons={buttons} onClick={handleClick} />
      {loading && <p>Carregando...</p>}
      {produto && <Produto produto={produto} />}
    </div>
  );
};

export default App;
