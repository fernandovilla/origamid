import React from 'react';
import Produto from './Produto';

function Start() {
  const [produto, setProduto] = React.useState(null);

  const style = {
    margin: '5px',
  };

  function handleClick({ target }) {
    setProduto(target.innerText);
    return null;
  }

  // Ocorre quando não há produto informado
  React.useEffect(() => {
    const produtoLocal = window.localStorage.getItem('produto');
    if (produtoLocal === null) return;

    setProduto(produtoLocal);
  }, []);

  // Ocorre quando produto é modificado
  React.useEffect(() => {
    if (produto !== null) {
      window.localStorage.setItem('produto', produto);
    }
  }, [produto]);

  return (
    <div>
      <h2>Peferência: {produto}</h2>
      <button onClick={handleClick} style={style}>
        notebook
      </button>
      <button onClick={handleClick} style={style}>
        smartphone
      </button>
      <Produto produto={produto} />
    </div>
  );
}

const App = () => {
  return Start();
};

export default App;
