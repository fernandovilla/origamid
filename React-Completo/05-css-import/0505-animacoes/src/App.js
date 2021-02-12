import React from 'react';
import './App.css';
import Produto from './Produto';

const App = () => {
  const [ativar, setAtivar] = React.useState(false);

  return (
    <div>
      <button onClick={() => setAtivar(!ativar)}>Ativar</button>
      {ativar && <Produto />}
    </div>
  );
};

export default App;
