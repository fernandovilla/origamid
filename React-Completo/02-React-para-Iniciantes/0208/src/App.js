import React from 'react';

const appProdutos = () => {
  const produtos = ['Before Sunrise', 'Before Sunset', 'Before Midnight'];
  return <p>{produtos}</p>;
};

const appFilmes = () => {
  const filmes = ['Before Sunrise', 'Before Sunset', 'Before Midnight'];

  return (
    <ul>
      {filmes.map((filme) => (
        <li key={filme}>{filme}</li>
      ))}
    </ul>
  );
};

const appLivros = () => {
  const livros = [
    { nome: 'A Game of Thrones', ano: 1996 },
    { nome: 'A Clash of Kings', ano: 1998 },
    { nome: 'A Storm of Swords', ano: 2000 },
  ];

  return (
    <ul>
      {livros
        .filter(({ ano }) => ano >= 1998)
        .map(({ nome, ano }) => (
          <li key={nome}>
            {nome}, {ano}
          </li>
        ))}
    </ul>
  );
};

const appExercicio = () => {
  // Organize os produtos como mostrado no vídeo
  // Mostre apenas produtos que forem mais caros que R$ 1500

  const produtos = [
    {
      id: 1,
      nome: 'Smartphone',
      preco: 'R$ 2000',
      cores: ['#29d8d5', '#252a34', '#fc3766'],
    },
    {
      id: 2,
      nome: 'Notebook',
      preco: 'R$ 3000',
      cores: ['#ffd045', '#d4394b', '#f37c59'],
    },
    {
      id: 3,
      nome: 'Tablet',
      preco: 'R$ 1500',
      cores: ['#365069', '#47c1c8', '#f95786'],
    },
  ];

  const produtosFilter = produtos.filter(
    ({ preco }) => Number(preco.replace('R$ ', '')) > 1500,
  );

  return (
    <section>
      {produtosFilter.map((produto) => (
        <div key={produto.id}>
          <h1>{produto.nome}</h1>
          <h2>{produto.preco}</h2>
          <ul>
            {produto.cores.map((cor) => (
              <li key={cor} style={{ backgroundColor: cor, color: 'white' }}>
                {cor}
              </li>
            ))}
          </ul>
        </div>
      ))}
    </section>
  );
};

const App = () => {
  //return appFilmes();
  //return appLivros();
  return appExercicio();
};

export default App;
