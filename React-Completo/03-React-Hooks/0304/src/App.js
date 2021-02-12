import React from 'react';

function operacaoLenta() {
  let c;
  for (let i = 0; i < 100000000; i++) {
    c = c + (i + i) / 10;
  }
  return c;
}

// Exemplo de React.useMemo();
// Pode ser utilizado em operações JS que requerem muito processamento e são executadas várias vezes
const Sample1 = () => {
  const [contar, setContar] = React.useState(0);

  const t1 = performance.now();
  //const valor = operacaoLenta();
  const valor = React.useMemo(() => operacaoLenta(), []);
  console.log(performance.now() - t1);

  return (
    <div>
      <button onClick={() => setContar(contar + 1)}>{contar}</button>
    </div>
  );
};

// Exemplo de React.useCallback();
// Pode ser utilizada para armazenar uma função de callback. Não será recriada toda vez que a página é renderizada;
const Sample2 = () => {
  const [contar, setContar] = React.useState(0);

  // function handleClick() {
  //   setContar(contar + 1);
  // }

  const handleClick = React.useCallback(() => {
    setContar((f) => f + 1); // 'f' representa o 'contar'
  }, []);

  return (
    <div>
      <button onClick={handleClick}>{contar}</button>
    </div>
  );
};

const App = () => {
  return Sample2();
};

export default App;
