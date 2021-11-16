import React from 'react';
import useLocalStorage from './Hooks/useLocalStorage';

const App = () => {
  const [produto, setProduto] = useLocalStorage('produto', '');

  console.log('Produto:' + produto);

  const handleClick = ({ target }) => {
    setProduto(target.innerText);
  };

  return (
    <div>
      <h1>0306 - Custom Hooks</h1>
      <button onClick={handleClick}>Notebook</button>
      <button onClick={handleClick}>Smartphone</button>
    </div>
  );
};

export default App;
