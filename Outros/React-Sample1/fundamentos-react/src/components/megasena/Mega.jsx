import React from 'react';

const Mega = (props) => {
  // Cria um array de tamanho 'qtdNumeros' e preenche com '0';
  const [numeros, setNumeros] = React.useState(Array(props.qtdNumeros).fill(0));

  const gerarNumerosNaoContidos = (array) => {
    const max = 60;
    const min = 1;
    const novoNumero = parseInt(Math.random() * (max - min)) + min;

    if (array.includes(novoNumero))
      return gerarNumerosNaoContidos(array);
    else
      return novoNumero;
  }

  const createNewNumbers = () => {
    const novoArray = Array(props.qtdNumeros)
      .fill(0)
      .reduce(a => [...a, gerarNumerosNaoContidos(a)], [])
      .sort((a,b) => a-b);
    
    setNumeros(novoArray);
  }

  return <div>
    <h2>Numeros:</h2>
    <p>{numeros.join('-')}</p>
    <button onClick={createNewNumbers}>Novos Números</button>
  </div>
}

export default Mega;