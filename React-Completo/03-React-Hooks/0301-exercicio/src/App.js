import React from 'react';
import Produto from './Produto';

const App = () => {
  const [produto, setProduto] = React.useState(null);
  const [loading, setLoading] = React.useState(null);

  async function handleClick(event) {
    setLoading(true);
    const produto = event.target.innerText;
    const urlFetch = `https://ranekapi.origamid.dev/json/api/produto/${produto}`;

    const response = await fetch(urlFetch);
    const json = await response.json();

    setProduto(json);
    setLoading(false);
  }

  const styleButton = {
    margin: '.5rem',
  };

  return (
    <div>
      <button style={styleButton} onClick={handleClick}>
        notebook
      </button>
      <button style={styleButton} onClick={handleClick}>
        smartphone
      </button>
      <button style={styleButton} onClick={handleClick}>
        tablet
      </button>
      {/* Se 'produto' é diferente de null, apresenta o componente 'Produto' */}
      {loading && <p>Carregando produto. Aguarde...</p>}
      {!loading && produto != null ? (
        <Produto produto={produto} />
      ) : (
        <p>Selecione um produto acima</p>
      )}
    </div>
  );
};

export default App;
