import React from 'react';
import useLocalStorage from './useLocalStorage';
import useFetch from './useFetch';

// Exemplo de uso de um custom hook - useLocalStorage;
const Sample1 = () => {
  const [produto, setProduto] = useLocalStorage('produto', '');

  function handleClick({ target }) {
    setProduto(target.innerText);
  }

  return (
    <div>
      <button onClick={handleClick}>notebook</button>
      <button onClick={handleClick}>smartphone</button>
      <button onClick={handleClick}>tablet</button>
    </div>
  );
};

// Exemplo de uso de um custom hook - useFetch;
const Sample2 = () => {
  const { request, data, loading, error } = useFetch();

  React.useEffect(() => {
    async function fetchDataAsync() {
      const { response, json } = await request(
        'https://ranekapi.origamid.dev/json/api/produto/',
      );
      console.log(response, json);
    }
    fetchDataAsync();
  }, [request]);

  if (error) return <p>Ocorreu erro ao carregar os produtos! {error}</p>;

  if (loading) return <p>Loading. Wait...</p>;

  if (data) {
    return (
      <div>
        <h3>Produtos:</h3>
        {data.map((item) => (
          <li key={item.id}>
            {item.nome}, R$ {item.preco}
          </li>
        ))}
      </div>
    );
  }

  return null;
};

const App = () => {
  return Sample2();
};

export default App;
