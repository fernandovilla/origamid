import React from 'react';

const Produto = ({ produto }) => {
  const [dados, setDados] = React.useState(null);

  React.useEffect(() => {
    if (produto !== null) {
      fetch(`https://ranekapi.origamid.dev/json/api/produto/${produto}`)
        .then((response) => response.json())
        .then((json) => setDados(json));
    }
  }, [produto]);

  React.useEffect(() => {
    console.log(dados);
  }, [dados]);

  if (dados === null) return null;

  return (
    <div>
      <h2>{dados.nome}</h2>
      <p>R$ {dados.preco}</p>
    </div>
  );
};

export default Produto;
