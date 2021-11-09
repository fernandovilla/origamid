import React from 'react';

const App = () => {
  //let ativo = true;
  const [ativo, setAtivo] = React.useState(true);
  const [dados, setDados] = React.useState({
    nome: 'Fernando Villa',
    idade: 38,
  });

  const handleClick = () => {
    // ativo = !ativo;
    setAtivo(!ativo);

    // Inclusão de uma nova propriedade em um objeto no hook
    // setDados({ ...dados, faculdade: 'Possui faculdade!' });
  };

  return (
    <div>
      <label>Nome: {dados.nome}</label>
      <label>Idade: {dados.idade}</label>
      <button onClick={handleClick}>{ativo ? 'Ativo' : 'Inativo'}</button>
    </div>
  );
};

export default App;
