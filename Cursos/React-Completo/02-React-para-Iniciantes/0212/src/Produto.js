import React from 'react';

const Produto = ({ produto }) => {
  const style = {
    border: '1px solid',
    margin: '1rem 0',
    padding: '1rem',
    borderRadius: '5px',
  };

  return (
    <div style={style}>
      <p>{produto.nome}</p>
      <ul>
        {produto.propriedades.map((prop) => (
          <li key={prop}>{prop}</li>
        ))}
      </ul>
    </div>
  );
};

export default Produto;
