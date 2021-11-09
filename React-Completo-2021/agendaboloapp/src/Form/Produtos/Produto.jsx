import React from 'react';

const ListaPropriedades = (propriedades) => {
  if (propriedades == null) return null;

  return (
    <ul>
      {propriedades.map((i) => {
        return <li key={i}>{i}</li>;
      })}
    </ul>
  );
};

const Produto = ({ nome, propriedades }) => {
  return (
    <div
      style={{ border: '1px solid black', margin: '1rem', padding: '0.5rem' }}
    >
      <p>{nome}</p>
      {ListaPropriedades(propriedades)}
    </div>
  );
};

export default Produto;
