import React from 'react';

const operacaoLenta = () => {
  let c;
  for (let i = 0; i < 10000000000; i++) {
    c = ((i + i) / 10) * 0.5;
  }
  return c;
};

const App = () => {
  const [contar, setContar] = React.useState(0);

  const t1 = performance.now();
  const valor = React.memo(() => operacaoLenta());
  console.log(performance.now() - t1);

  // Cria a função 'handleClick' apenas uma vez, mesmo que a aplicação seja renderizada 10x;
  const handleClick = React.useCallback(() => {
    setContar((c) => c + 1);
  }, []);

  return (
    <div>
      <button onClick={handleClick}>{contar}</button>
    </div>
  );
};

export default App;
