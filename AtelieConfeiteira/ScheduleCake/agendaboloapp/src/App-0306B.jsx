import React from 'react';
import useFetch from './Hooks/useFetch';

const App = () => {
  const { request, data, loading, error } = useFetch();

  React.useEffect(() => {
    async function fetchData() {
      const result = await request(
        'https://ranekapi.origamid.dev/json/api/produto/',
      );
      const { response, json } = result;
    }
    fetchData();
  }, [request]);

  const ListData = () => {
    if (data === null) return null;

    return data.map((produto, index) => {
      return <li key={index}>{produto.nome}</li>;
    });
  };

  return (
    <div>
      <h1>0306 - Custom Hooks II </h1>
      {loading && <p>Carregando produtos...</p>}
      {error && <p>Ocorreu erro carregando os produtos</p>}
      {data && <ListData />}
    </div>
  );
};

export default App;
