import React from 'react';

const App = () => {
  const [count, setCount] = React.useState(0);
  const [prod, setProd] = React.useState(null);

  // Executa sempre o valor de 'count' for alterado, indicado no segundo parâmetro: [count]
  React.useEffect(() => {
    document.title = `Total ${count}`;
  }, [count]);

  // Executa uma única vez, indicado pelo segundo parâmetro, array vazio: []
  React.useEffect(() => {
    fetchProduto();
  }, []);

  const fetchProduto = async () => {
    const response = await fetch(
      'https://ranekapi.origamid.dev/json/api/produto/notebook',
    );

    const json = await response.json();
    setProd(json);
  };

  return (
    <div>
      {prod && (
        <div>
          <h1>{prod.nome}</h1>
          <p>R$ {prod.preco * count}</p>
        </div>
      )}
      <button onClick={() => setCount(count + 1)}>{count}</button>
    </div>
  );
};

export default App;
